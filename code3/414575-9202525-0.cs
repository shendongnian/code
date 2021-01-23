        _Application docExcel = new Microsoft.Office.Interop.Excel.Application();
        docExcel.Visible = false;
        docExcel.DisplayAlerts = false;
 
        _Workbook workbooksExcel = docExcel.Workbooks.Open(@"C:\test.xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
        _Worksheet worksheetExcel = (_Worksheet)workbooksExcel.ActiveSheet;
 
        ((Range)worksheetExcel.Cells["1", "A"]).Value2 = "aa";
        ((Range)worksheetExcel.Cells["1", "B"]).Value2 = "bb";
        workbooksExcel.Save();
        workbooksExcel.Close(false, Type.Missing, Type.Missing);
        docExcel.Application.DisplayAlerts = true;
        docExcel.Application.Quit();
