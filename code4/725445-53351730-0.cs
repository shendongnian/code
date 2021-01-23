     class DataReader
        {
            Excel.Application xlApp;
            Excel.Workbook xlBook;
            Excel.Range xlRange;
            Excel.Worksheet xlSheet;
            public DataTable GetSheetDataAsDataTable(String filePath, String sheetName)
            {
                DataTable dt = new DataTable();
                try
                {
                    xlApp = new Excel.Application();
                    xlBook = xlApp.Workbooks.Open(filePath);
                    xlSheet = xlBook.Worksheets[sheetName];
                    xlRange = xlSheet.UsedRange;
                    DataRow row=null;
                    for (int i = 1; i <= xlRange.Rows.Count; i++)
                    {
                        if (i != 1)
                            row = dt.NewRow();
                        for (int j = 1; j <= xlRange.Columns.Count; j++)
                        {
                            if (i == 1)
                                dt.Columns.Add(xlRange.Cells[1, j].value);
                            else
                                row[j-1] = xlRange.Cells[i, j].value;
                        }
                        if(row !=null)
                            dt.Rows.Add(row);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    xlBook.Close();
                    xlApp.Quit();
                }
                return dt;
            }
        }
