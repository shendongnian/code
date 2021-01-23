        var excel = new Microsoft.Office.Interop.Excel.Application();
        var workbook = excel.Workbooks.Add(true);
        // to add a sheet to workbook
        AddExcelSheet(dataTable1, workbook, "Sheet Name");
        string spreadsheetName = "DefaultFilename";
        excel.DisplayAlerts = false;
        Dialog saveAsDialog = excel.Dialogs[XlBuiltInDialog.xlDialogSaveAs];
    
        // to show dialog box with default filename
        saveAsDialog.Show(spreadsheetName);
        workbook.Close(true);
        excel.Quit();
        System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
