    using Excel = Microsoft.Office.Interop.Excel;
    Excel.Application xlApp = new Excel.Application();
    Excel.Workbook xlWorkbook = xlApp.Load("somefile.xls");
    Excel.Worksheet xlWorksheet = xlWorkbook.Worksheets[0]; // assume it is the first sheet
    Excel.Range xlRange = xlWorksheet.UsedRange; // get the entire used range
    int value = 0;
    if(Int32.TryParse(xlRange.Cells[1,6].Value2.ToString(), out value)) // get the F cell from the first row
    {
       int numberOfColumnsToRead = value * 4;
       for(int col=7; col < (numberOfColumnsToRead + 7); col++)
       {
          Console.WriteLine(xlRange.Cells[1,col].Value2.ToString()); // do whatever with value
       }
    }
