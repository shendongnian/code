    var excelApp = new Excel.Application();
    Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(path, 0, false, 5, "", "", false, XlPlatform.xlWindows, "", true, false, 0, true, false, false);
    Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelWorkbook.Sheets[2];
    Excel.Range excelRange = excelWorksheet.UsedRange;
    int rowCount = excelRange.Rows.Count;
    int colCount = excelRange.Columns.Count;
    string wwdEmpty = Convert.ToString(excelRange.Cells[5, 14].value2);
    // this is working code with NULL Excell cell 
