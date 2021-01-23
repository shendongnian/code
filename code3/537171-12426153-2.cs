    using Excel = Microsoft.Office.Interop.Excel.Application;
    
    Excel _excel = new Excel();
    
    Microsoft.Office.Interop.Excel.Workbook wb = _excel.Workbooks.Add();
    Microsoft.Office.Interop.Excel.Worksheet[] collection = new Microsoft.Office.Interop.Excel.Worksheet[20];
    for(int i = 1; i <= 20; i++)
    {
        collection[i] = wb.Worksheets.Add();
        collection[i].Name = String.Format("Test {0}", i);
    }
    //collection is an array of worksheet objects,
    //the worksheet objects in your workbook.
    //You can access each individual worksheet and
    //work with it in the same way you access any object in an array
    Microsoft.Office.Interop.Excel.Worksheet thisWorksheet = collection[9];
    Microsoft.Office.Interop.Excel.Range thisRange = thisWorksheet.get_Range("A1");
    thisRange.Value = "Hello World";
    wb.SaveAs(@"c:\whatever.xlsx");
    wb.Close();
