    Microsoft.Office.Interop.Excel.Application xlApp;
    Workbook wb = null;
    try
    {
    wb = xlApp.Workbooks.Open(filePath, false, true,5,null,"WrongPAssword");
    }
    
    foreach (object possibleSheet in wb.Sheets)
       {
       var aSheet = possibleSheet as Worksheet;
         if (aSheet != null)
         {
    ....
