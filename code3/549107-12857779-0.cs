    Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
    Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Open("some.xlsx");
    // For each worksheet we got
    foreach (Microsoft.Office.Interop.Excel.Worksheet worksheet in xlWorkbook.Sheets) 
    {   // and each pivot table in each worksheet
        foreach (Microsoft.Office.Interop.Excel.PivotTable pivot in worksheet.PivotTables())
        {   // disable BackgroundQuery
            pivot.PivotTableWizard(BackgroundQuery: false);
        }
    }
    // try to refresh all sheet
    try { xlWorkbook.RefreshAll(); } catch { }
    // then save
    xlWorkbook.Save();
