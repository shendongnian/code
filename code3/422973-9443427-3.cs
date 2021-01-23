        And add this namespace in your code behind
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using Excel = Microsoft.Office.Interop.Excel; 
        using System.IO;
        using System.Data; 
         static void Main(string[] args)
        {
            string Path = @"C:\samples\SEP DUMPS.xls";
            // initialize the Excel Application class
            Excel.Application app = new Excel.Application();           
            //Excel.Worksheet NwSheet;
            Excel.Range ShtRange;
            // create the workbook object by opening  the excel file.
            Excel.Workbook workBook = app.Workbooks.Open(Path,0,true,5,"","",true,Excel.XlPlatform.xlWindows,"\t",false,false, 0,true,1,0);
            // Get The Active Worksheet Using Sheet Name Or Active Sheet
            Excel.Worksheet workSheet = (Excel.Worksheet)workBook.ActiveSheet;
            int index = 1;
            // that is which cell in the excel you are interesting to read.
            object rowIndex = 1;
            object colIndex1 = 1;
            object colIndex2 = 5;
            object colIndex3 = 4;
            System.Text.StringBuilder sb = new StringBuilder();
            try
            {
                while (((Excel.Range)workSheet.Cells[rowIndex, colIndex1]).Value2 != null)
                {
                    rowIndex =index;
                    string firstName = Convert.ToString( ((Excel.Range)workSheet.Cells[rowIndex, colIndex1]).Value2);
                    string lastName = Convert.ToString(((Excel.Range)workSheet.Cells[rowIndex, colIndex2]).Value2);
                    string Name = Convert.ToString(((Excel.Range)workSheet.Cells[rowIndex, colIndex3]).Value2);
                    string line = firstName + "," + lastName + "," + Name;
                    sb.Append(line); sb.Append(Environment.NewLine);
                    Console.WriteLine(" {0},{1},{2} ", firstName, lastName,Name);
                    index++;
                }
               Writetofile(sb.ToString());
                
                ShtRange = workSheet.UsedRange;
                Object[,] s = ShtRange.Value;            
                
            }
            catch (Exception ex)
            {
                app.Quit();
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
           
        }
