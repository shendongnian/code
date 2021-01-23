    // infile is the excel file, outfile is the pdf to build, sheetToExport is the name of the sheet
    public static void ExportExcel(string infile, string outfile, string sheetToExport) 
    { 
        Excel.Application excelApp = null; 
        try 
        { 
            string tempFile = Path.ChangeExtension(outfile, "XLS");
            File.Copy(infile, tempFile, true);
            excelApp = new Excel.Application(); 
            excelApp.Workbooks.Open(tempFile); 
            for(int x = excelApp.Workbooks[0].Sheet.Count - 1; x > 0; x++)
            {
                if(excelApp.Workbooks[0].WorkSheets[x].Name != sheetToExport)
                     excelApp.Workbooks[0].WorkSheets[x].Delete();
            } 
            excelApp.ActiveWorkbook.ExportAsFixedFormat(Excel.XlFixedFormatType.xlTypePDF, outfile); 
        } 
        finally 
        { 
            if (excelApp != null) 
            { 
                excelApp.DisplayAlerts = false; 
                excelApp.SaveWorkspace(); 
                excelApp.Quit(); 
            } 
         } 
    } 
