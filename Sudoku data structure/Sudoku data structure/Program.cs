using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_data_structure
{
    class Program
    {
        static void Main(string[] args)
        {
            //////// following will check for GOOD AND BAD sudoku validation //////
            int[][] goodSudoku1 = {
                new int[] {7,8,4,  1,5,9,  3,2,6},
                new int[] {5,3,9,  6,7,2,  8,4,1},
                new int[] {6,1,2,  4,3,8,  7,5,9},
                new int[] {9,2,8,  7,1,5,  4,6,3},
                new int[] {3,5,7,  8,4,6,  1,9,2},
                new int[] {4,6,1,  9,2,3,  5,8,7},
                new int[] {8,7,6,  3,9,4,  2,1,5},
                new int[] {2,4,3,  5,6,1,  9,7,8},
                new int[] {1,9,5,  2,8,7,  6,3,4}
            };
            Sudoku goodsudoku1 = new Sudoku(goodSudoku1);
            goodsudoku1.length = 9;
            goodsudoku1.squareOf = 3;
            Console.WriteLine(goodsudoku1.Validate());

            int[][] goodSudoku2 = {
                new int[] {1,4, 2,3},
                new int[] {3,2, 4,1},

                new int[] {4,1, 3,2},
                new int[] {2,3, 1,4}
            };
            Sudoku goodsudoku2 = new Sudoku(goodSudoku2);
            goodsudoku2.length = 4;
            goodsudoku2.squareOf = 2;
            Console.WriteLine(goodsudoku2.Validate());

            int[][] badSudoku1 =  {
                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9},

                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9},

                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9}
            };
            Sudoku badsudoku1 = new Sudoku(badSudoku1);
            badsudoku1.length = 9;
            badsudoku1.squareOf = 3;
            Console.WriteLine(badsudoku1.Validate());

            int[][] badSudoku2 = {
                new int[] {1,2,3,4,5},
                new int[] {1,2,3,4},
                new int[] {1,2,3,4},
                new int[] {1}
            };
            Sudoku Badsudoku = new Sudoku(badSudoku2);
            Badsudoku.length = 4;
            Badsudoku.squareOf = 2;
            Console.WriteLine(Badsudoku.Validate());
            ////////end of sudoku validation///////

            Console.WriteLine("Press enter to close...");
            Console.ReadLine();
            
        }
    }
    public class Sudoku
    {
        public int length;
        public int squareOf;
        private int[][] sudoku;       
       
        public Sudoku(int[][] sudoku)
        {
            // TODO: Validate bounds and values
            this.sudoku = sudoku;
        }
        public bool Validate() =>
            VerticalLines.All(IsValid)
            && HorizontalLines.All(IsValid)
            && Squares.All(IsValid);

        IEnumerable<IEnumerable<int>> VerticalLines =>
            from line in sudoku select line;

        IEnumerable<IEnumerable<int>> HorizontalLines =>
            from y in Enumerable.Range(0, length)
            select (
                from x in Enumerable.Range(0, length)
                select sudoku[x][y]);

        IEnumerable<IEnumerable<int>> Squares =>
            from x in Enumerable.Range(0, squareOf)
            from y in Enumerable.Range(0, squareOf)
            select GetSquare(x, y);

        IEnumerable<int> GetSquare(int x, int y) =>
            from squareX in Enumerable.Range(0, squareOf)
            from squareY in Enumerable.Range(0, squareOf)
            select sudoku[x * squareOf + squareX][y * squareOf + squareY];

        bool IsValid(IEnumerable<int> line) => !(
            from item in line
            group item by item into g
            where g.Count() > 1
            select g)
            .Any();
    }
}
