    using Excel = Microsoft.Office.Interop.Excel;
    var st = System.IO.Directory.GetCurrentDirectory() + "\\A.xlsx";
    
    var xlApp = new Excel.Application();
    var xlWorkBook = xlApp.Workbooks.Open(st);
    var xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.Item[1];
    
    for (var i = 6; i < 10; i++)
    {
        MessageBox.Show(xlWorkSheet.Range["L" + @i, "L" + @i].Value2.ToString());
    }
    
    //make some changes here
    
    xlWorkBook.Save();
    xlWorkBook.Close();
    xlApp.Quit();
