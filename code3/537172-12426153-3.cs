    using Excel = Microsoft.Office.Interop.Excel;
    
    void MyMethod()
    {
        var _excel = new Excel.Application();
    
        var wb = _excel.Workbooks.Add();
        var collection = new Excel.Worksheet[20];
    
        for (var i = 0; i < 20; i++)
        {
            collection[i] = wb.Worksheets.Add();
            collection[i].Name = String.Format("Test {0}", i + 1);
        }
    
        //collection is an array of worksheet objects,
        //the worksheet objects in your workbook.
        //You can access each individual worksheet and
        //work with it in the same way you access any object in an array
    
        var thisWorksheet = collection[9];
        var thisRange = thisWorksheet.Range["A1"];
        thisRange.Value = "Hello World";
    
        wb.SaveAs(@"c:\test\whatever.xlsx");
        wb.Close();
    }
