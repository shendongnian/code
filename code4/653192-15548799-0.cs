    string fileName = @"C:\Users\L-3\Desktop\my.xlsx";
    string svfileName = @"C:\Users\L-3\Desktop\ssc\my1.xls";
    object oMissing = Type.Missing;
    var app = new Microsoft.Office.Interop.Excel.Application();
    var wb = app.Workbooks.Open(fileName, oMissing, oMissing,
                    oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing);
    wb.SaveAs(svfileName, XlFileFormat.xlExcel8, Type.Missing, Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
    app.Quit();
