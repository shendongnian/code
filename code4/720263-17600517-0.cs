    using System;
    using Microsoft.Office.Interop.Excel;
    
    namespace StackOverflowExample
    {
        class Program
        {
            static void Main(string[] args)
            {
                var app = new Application();
                var wkbk = app.Workbooks.Open(@"c:\data\foo.xls") as Workbook;
                var wksht = wkbk.Sheets[1] as Worksheet; // not zero-based!
                for (int row = 1; row <= 100; row++) // not zero-based!
                {
                    Console.WriteLine("This is row #" + row.ToString());
                    for (int col = 1; col <= 100; col++)
                    {
                        Console.WriteLine("This is col #" + col.ToString());
                        var cell = wksht.Cells[row][col] as Range;
                        if (cell != null)
                        {
                            object val = cell.Value;
                            if (val != null)
                            {
                                Console.WriteLine("The value of the cell is " + val.ToString());
                            }
                        }
                    }
                }
            }
        }
    }
