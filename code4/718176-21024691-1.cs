     using Microsoft.Office.Interop.Excel;
    
     Application xls = null;
     Workbooks workBooks = null;
     Workbook workBook = null;
     Sheets sheets = null;
     Worksheet workSheet1 = null;
     Worksheet workSheet2 = null;
    
     workBooks = xls.Workbooks;
     workBook = workBooks.Open(workSpaceFile);
     sheets = workBook.Worksheets;
     workSheet1 = (Worksheet)sheets[1];
    
    
    // removing from Memory
     if (xls != null)
     {    
       foreach (Microsoft.Office.Interop.Excel.Worksheet sheet in sheets)
       {
          ReleaseObject(sheet);
       }
    
       ReleaseObject(sheets);
       workBook.Close();
       ReleaseObject(workBook);
       ReleaseObject(workBooks);
       
       xls.Application.Quit(); // THIS IS WHAT IS CAUSES EXCEL TO CLOSE
       xls.Quit();
       ReleaseObject(xls);
    
       sheets = null;
       workBook = null;
       workBooks = null;
       xls = null;
    
       GC.Collect();
       GC.WaitForPendingFinalizers();
       GC.Collect();
       GC.WaitForPendingFinalizers();
    }
