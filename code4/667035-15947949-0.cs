    Excel.Application xlApp = new Excel.Application();
    Excel.Workbooks xlWorkbooks = xlApp.Workbooks;
    Excel.Workbook xlWorkbook = xlWorkbooks.Open(file);
    ....    
    System.Runtime.InteropServices.Marshal.FinalReleaseComObject(xlApp);
    System.Runtime.InteropServices.Marshal.FinalReleaseComObject(xlWorkbooks);
    System.Runtime.InteropServices.Marshal.FinalReleaseComObject(xlWorkbook);
    ....    
