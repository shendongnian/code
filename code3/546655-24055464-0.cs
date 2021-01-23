    public void ReadEx(string sHeet, int startfromrow)
           {
              excelTable.Clear();
              string excelFile =  "filepath";
              Excel.Application excel = new Excel.Application();
              Excel.Workbook wb = excel.Workbooks.Open(excelFile);
              Excel.Worksheet pivotWorkSheet = (Excel.Worksheet)wb.Sheets[sHeet];
              Excel.Range xlRange = pivotWorkSheet.UsedRange;
    
              int rowCount = xlRange.Rows.Count;
              int colCount = xlRange.Columns.Count;
    
    
              if (excelTable.Columns.Count <= 0)
                {
                  excelTable.Columns.Add("Row Labels");
                  foreach (string column in lColumns)
                  {
                      excelTable.Columns.Add(column);
                  }
                }
                  
              object[] exrow = new object[colCount];
              for (int i; startfromrow <= rowCount; row++)
              {
                  for (int j = 1; j <= colCount; j++)
                  {
                      exrow[j-1] = xlRange.Cells[startfromrow , j].Text;
                      Console.WriteLine(xlRange.Cells[startfromrow , j].Text);
                  }
                  excelTable.Rows.Add(exrow);
              }
