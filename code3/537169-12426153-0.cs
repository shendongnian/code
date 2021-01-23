    using Excel = Microsoft.Office.Interop.Excel.Application;
    
    Excel _excel = new Excel();
    
    Microsoft.Office.Interop.Excel.Workbook wb = _excel.Workbooks.Add();
    Microsoft.Office.Interop.Excel.Worksheet ws = wb.Worksheets.Add();
    //ws is a Microsoft.Office.Interop.Excel.Worksheet object, do what you want to do with your worksheet here
    wb.SaveAs(@"c:\whatever.xlsx");
    wb.Close();
