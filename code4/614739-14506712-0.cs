      using (StreamWriter sw = File.CreateText("ExtractedText.txt"))
                {
                    Excel.Application xlApp = new Excel.Application();
                    Excel.Workbook thisWkBook = xlApp.Workbooks.Open(thisFile);
        
                    foreach (Excel.Worksheet sheet in thisWkBook.Worksheets)
                    {
                        
                    int rowCount = sheet.UsedRange.Rows.Count;
                    int colCount = sheet.UsedRange.Columns.Count;
        
                    for (int i = 1; i <= rowCount; i++)
                    {
                        for (int j = 1; j <= colCount; j++)
                        {
                          sw.WriteLine(sheet.UsedRange.Cells[i, j].Value2.ToString());
                           
                        }
                    }
                    }
                }
