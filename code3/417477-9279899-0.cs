    using Excel = Microsoft.Office.Interop.Excel;
    private int rowsBefore = 0;
    
    void SomeMethod() {
        Excel.Application app = new Excel.Application();
        Excel.Workbook wb = app.Workbooks.Add();
        Excel.Worksheet ws = (Excel.Worksheet)wb.Worksheets[0];
        ws.SelectionChange += new Excel.DocEvents_SelectionChangeEventHandler(ws_SelectionChange);
    }
    void ws_SelectionChange(Excel.Range Target) {
        int rowsNow = Target.Rows.Count;
        if (rowsNow > rowsBefore) {
            // do stuff
        }
        rowsBefore = rowsNow;
    }
