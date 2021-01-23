        _Application docExcel = new Microsoft.Office.Interop.Excel.Application { Visible = false };
       dynamic workbooksExcel = docExcel.Workbooks.Open(@"C:\Users\mahmut.efe\Desktop\Book4.xlsx");
       var worksheetExcel = (_Worksheet)workbooksExcel.ActiveSheet;
    
       ((Range)worksheetExcel.Rows[2, Missing.Value]).Delete(XlDeleteShiftDirection.xlShiftUp);
    
       workbooksExcel.Save();
       workbooksExcel.Close(false);
       docExcel.Application.Quit();
