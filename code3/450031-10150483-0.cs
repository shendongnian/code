    using Excel = Microsoft.Office.Interop.Excel;
    Excel.Application xlApp; 
    Excel.Workbook xlWorkBook; 
    Excel.Worksheet xlWorkSheet; 
    object misValue = System.Reflection.Missing.Value; 
 
    xlApp = new Excel.ApplicationClass(); 
    xlWorkBook = xlApp.Workbooks.Open(_filename, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0); 
    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1); 
 
    //Attribute a value to a cell
    var cell = (Range)xlWorkSheet .Cells[row, column];
    cell.Value2 = "Test";
    //This should print
    xlWorkBook.PrintOut (Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
    xlWorkBook.Close(false, misValue, misValue); 
    xlApp.Quit(); 
    
