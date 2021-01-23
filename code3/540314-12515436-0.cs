    using System;
    using System.Collections.Generic;
    using Excel = Microsoft.Office.Interop.Excel;
    
    namespace Excel_10_Random_Rows
    {
        class Program
        {
            static void Main()
            {
                Excel.Application excel = new Excel.Application();
                Excel.Workbook workbook = excel.Workbooks.Open(@"C:\test.xlsx");
                Excel.Worksheet worksheet = workbook.Worksheets[1];
    
                Excel.Range[] rows = new Excel.Range[10];
    
                List<int> rowNumbers = new List<int>();
    
                bool tenUniqueNumbers = false;
    
                Random random = new Random();
    
                while (!tenUniqueNumbers)
                {
                    int nextNumber = random.Next(0, 99);
    
                    if(!rowNumbers.Contains(nextNumber))
                    rowNumbers.Add(random.Next());
    
                    if (rowNumbers.Count == 10)
                    {
                        tenUniqueNumbers = true;
                    }
                }
    
                for (int i = 0; i < 10; i++)
                {
                    rows[i] = worksheet.Rows[rowNumbers[i]];
                }
                //rows is now an array of Excel.Range objects containing 10 random rows
            }
        }
    }
