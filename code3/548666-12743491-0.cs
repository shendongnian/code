    Excel.Range headerRange = xlWorkSheet1.get_Range("A1", "V1");
    headerRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
    headerRange.Value = "Header text 1";
    
    headerRange = xlWorkSheet2.get_Range("A1", "V1");
    headerRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
    headerRange.Value = "Header text 2";
