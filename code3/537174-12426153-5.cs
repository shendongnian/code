    using System;
    using System.Runtime.InteropServices;
    using Excel = Microsoft.Office.Interop.Excel;
    
    void MyMethod()
    {
        try
        {
            var _excel = new Excel();
    
            var wb = _excel.Workbooks.Add();
            var collection = new Microsoft.Office.Interop.Excel.Worksheet[20];
    
            for (var i = 19; i >= 0; i--)
            {
                collection[i] = wb.Worksheets.Add();
                collection[i].Name = String.Format("test{0}", i + 1);
            }
    
            for (var i = 0; i < 3; i++)
            {
                wb.Worksheets[21].Delete();
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
        finally
        {
            Marshal.ReleaseComObject(_excel);
        }
    }
