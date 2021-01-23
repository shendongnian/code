    object misValue = System.Reflection.Missing.Value;
    Microsoft.Office.Interop.Excel.Application appExcel = new 
    Microsoft.Office.Interop.Excel.Application();
    appExcel.Visible = false;
    Microsoft.Office.Interop.Excel.Workbook workbook = appExcel.Workbooks.Add(misValue);
    Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];
    workbook.SaveAs(Environment.CurrentDirectory + @"\a.xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
    
