    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace Demo
    {
        class Program
        {
            // Array will 4x3 (rows x cols):
            //
            //  1  2  3 |  6
            //  4  5  6 | 15
            //  7  8  9 | 24
            // 10 11 12 | 33
            // ---------
            // 22 26 30
            int[] numbers = Enumerable.Range(1, 12).ToArray();
            int totalColumns = 3;
            int totalRows    = 4;
            int numberAt(int row, int col)
            {
                return numbers[row * totalColumns + col];
            }
            void test()
            {
                int[] colTotals = new int[totalColumns];
                int[] rowTotals = new int[totalRows];
                for (int row = 0; row < totalRows; ++row)
                {
                    for (int col = 0; col < totalColumns; ++col)
                    {
                        int number = numberAt(row, col);
                        rowTotals[row] += number;
                        colTotals[col] += number;
                    }
                }
                Console.WriteLine("Row totals");
                foreach (int rowTotal in rowTotals)
                    Console.Write(rowTotal + " ");
            
                Console.WriteLine("\nCol totals");
                foreach (int colTotal in colTotals)
                    Console.Write(colTotal + " ");
                Console.WriteLine();
            }
            static void Main()
            {
                new Program().test();
            }
        }
    }
                                                                              
