    public void test(Application xlApp)
    {
        string file = @"C:\Temp\a.xlsx";
        Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(file);
        Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
        xlWorksheet.Range["A1"].EntireRow.Copy(); 
        Excel.Workbook xlWorkbookNew = xlApp.Workbooks.Add();
        Excel._Worksheet xlWorksheetNew = xlWorkbookNew.Sheets[1];
        Worksheet activeSheet = xlWorkbookNew.ActiveSheet;
        activeSheet.Paste();
    
        xlWorkbook.Close(false);
        xlWorkbookNew.SaveAs(Path.Combine(@"C:\Temp", Path.GetFileName(file)));
        xlWorkbookNew.Close(true);
        CloseExcel();
    }
    
    public void CloseExcel(Application xlApp)
    {
        try
        {
            if (xlApp != null)
            {
                xlApp.Quit();
                if (Marshal.IsComObject(xlApp))
                    Marshal.ReleaseComObject(xlApp);
            }
        }
        catch (Exception ex)
        {
        }
    }
