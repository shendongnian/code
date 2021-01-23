    Excel.Application XlApp = null;
    Excel.Workbook workbook = null;
    Excel.Worksheet Ws = null;
    XlApp = new Excel.Application();
    XlApp.Visible = true;
    workbook = XlApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
    
    // here you get the first ws, index 1
    Ws = (Excel.Worksheet)workbook.Worksheets[1];
    workbook.Worksheets.Add(Missing.Value, Missing.Value,
    6, Missing.Value);
    var SheetName = "sheet_";
    // here you should start from 1 (not from 0) and include 7 in the loop count
    for (int j = 1; j <= 7; j++)
    {
        // make sure that the ws name is unique
        SheetName=String.Format("sheet_{0}",j);
        Ws = (Excel.Worksheet)workbook.Worksheets[j];
        Ws.Activate();
        Ws.Name = SheetName;// this is already a string
    }
    XlApp.Quit();
