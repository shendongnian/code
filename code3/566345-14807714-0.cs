    Worksheet ws = CommonData._WORKBOOK.Application.ActiveSheet as Worksheet;
    
    var _with1 = ws.PageSetup;
    _with1.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlLandscape;
    CommonData._WORKBOOK.Application.Dialogs[Microsoft.Office.Interop.Excel.XlBuiltInDialog.xlDialogPrint].Show(Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
