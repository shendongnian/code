        Excel.Application xlApp = new Excel.Application();
        Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"C:/myexcel.xlsx");
        Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
        Excel.Range xlRange = xlWorksheet.UsedRange;
        int rowCount = xlRange.Rows.Count;
        int colCount = xlRange.Columns.Count;
        for (int i = 1; i &lt;= rowCount; i++)
        {
            for (int j = 1; j &lt;= colCount; j++)
            {
                MessageBox.Show(xlRange.Cells[i, j].Value2.ToString());
            }
        }
