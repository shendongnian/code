         Excel.Application xlApp = new Excel.Application();
         Excel.Workbook xlWorkbook = xlApp.Workbooks.Open("workbookname");
         Excel.Worksheet xlWorksheet = xlWorkbook.Sheets[1]; // assume it is the first sheet
         int columnCount = xlWorksheet.UsedRange.Columns.Count;
         List<string> columnNames = new List<string>();
         for (int c = 1; c < columnCount; c++)
         {
             if (xlWorksheet.Cells[1, c].Value2 != null)
             {
                 string columnName = xlWorksheet.Columns[c].Address;
                 Regex reg = new Regex(@"(\$)(\w*):");
                 if (reg.IsMatch(columnName))
                 {
                     Match match = reg.Match(columnName);             
                     columnNames.Add(match.Groups[2].Value);
                 }                      
            }
         }
