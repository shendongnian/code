    // infile is the excel file, outfile is the pdf to build, sheetToExport is the name of the sheet
    public static void ExportExcel(string infile, string outfile, string sheetToExport) 
    { 
        Microsoft.Office.Interop.Excel.Application excelApp = new     
                            Microsoft.Office.Interop.Excel.Application();
        try  
        {  
            string tempFile = Path.ChangeExtension(outfile, "XLS"); 
            File.Copy(infile, tempFile, true); 
            Microsoft.Office.Interop.Excel._Workbook excelWorkbook = 
                                    excelApp.Workbooks.Open(tempFile);  
		
            for(int x = excelApp.Sheets.Count; x > 0; x--) 
            { 
                _Worksheet sheet = (_Worksheet)excelApp.Sheets[x];
                if(sheet != null && sheet.Name != sheetToExport) 
                    sheet.Delete(); 
            }  
            excelApp.ActiveWorkbook.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF, outfile);  
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
