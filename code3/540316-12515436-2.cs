    using System;
    using System.Collections.Generic;
    using Excel = Microsoft.Office.Interop.Excel;
    
    namespace Excel_10_Random_Rows
    {
        class Program
        {
            static void Main(string[] args)
            {
                Excel.Range[] rows = RandomRows(10, @"C:\test.xlsx");
            }
    
            private static Excel.Range[] RandomRows(int randomRowsToGet, string worksheetLocation, int worksheetNumber = 1, int lowestRow = 0, int highestRow = 99)
            {
                Excel.Range[] rows = new Excel.Range[randomRowsToGet];
    
                Excel.Application excel = new Excel.Application();
                Excel.Workbook workbook = excel.Workbooks.Open(worksheetLocation);
                Excel.Worksheet worksheet = workbook.Worksheets[worksheetNumber];
    
                List<int> rowNumbers = new List<int>();
    
                bool allUniqueNumbers = false;
    
                Random random = new Random();
    
                while (!allUniqueNumbers)
                {
                    int nextNumber = random.Next(lowestRow, highestRow);
    
                    if (!rowNumbers.Contains(nextNumber))
                        rowNumbers.Add(nextNumber);
    
                    if (rowNumbers.Count == randomRowsToGet)
                        allUniqueNumbers = true;
                }
    
                for (int i = 0; i < randomRowsToGet; i++)
                {
                    rows[i] = worksheet.Rows[rowNumbers[i]];
                }
    
                return rows;
            }
        }
    }
