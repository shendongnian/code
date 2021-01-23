    Static void Main()
    {
        var excel = new Microsoft.Office.Interop.Excel.Application();
        var workbook = excel.Workbooks.Add(true);
        AddExcelSheet(dt1, workbook);
        AddExcelSheet(dt2, workbook);
        workbook.SaveAs(@"C:\MyExcelWorkBook2.xlsx");
        workbook.Close();
    }
    private static void AddExcelSheet(DataTable dt, Workbook wb)
    {    
        Excel.Sheets sheets = wb.Sheets;
        Excel.Worksheet newSheet = sheets.Add;
        int iCol = 0;
        foreach (DataColumn c in dt.Columns)
        {
            iCol++;
            newSheet.Cells[1, iCol] = c.ColumnName;
        }
        int iRow = 0;
        foreach (DataRow r in dt.Rows)
        {
            iRow++;
            // add each row's cell data...
            iCol = 0;
            foreach (DataColumn c in dt.Columns)
            {
                iCol++;
                newSheet.Cells[iRow + 1, iCol] = r[c.ColumnName];
            }
    }
