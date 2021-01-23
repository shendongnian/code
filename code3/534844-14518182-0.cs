    object misValue = System.Reflection.Missing.Value;
    // COMM creates a wrapper for each object and they don't get cleaned up.  Never use 2 dots with comm
    Excel.ApplicationClass xlApp = new Excel.ApplicationClass();
    Excel.Workbooks xlWorkbooks = xlApp.Workbooks;
    Excel.Workbook xlWorkbook  = xlWorkbooks.Open(fileInfo.getFileURL(), misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue);
    Excel.Worksheet xlWorksheet = (Excel.Worksheet)xlWorkbook.Sheets[1];
    Excel.Range xlRange, r;
    try
    {
        xlRange = (Excel.Range)xlWorksheet.UsedRange;
        int rowCount = xlRange.Rows.Count;
        int colCount = xlRange.Columns.Count;
        for (int col = 0; col < colCount; col++)
        {
            r = (Excel.Range)xlRange.Cells[fileInfo.columnHeaders, (col + 1)];
        }
    }
