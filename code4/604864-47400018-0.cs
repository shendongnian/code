    // Step 1. Download NuGet source of Generic Parsing by Andrew Rissing
    // Step 2. Reference this to your project
    // Step 3. Reference Microsoft.Office.Interop.Excel to your project
    // Step 4. Follow the logic below
    public static DataTable ExcelSheetToDataTable(string filePath) {
        // Save a copy of the Excel file as CSV
        var xlApp = new XL.Application();
        var xlWbk = xlApp.Workbooks.Open(filePath);
        var tempPath =
            Path.Combine(Environment
                .GetFolderPath(Environment.SpecialFolder.UserProfile)
                , "AppData"
                , "Local",
                , "Temp"
                , Path.GetFileNameWithoutExtension(filePath) + ".csv");
        
        xlApp.DisplayAlerts = false;
        xlWbk.SaveAs(tempPath, XL.XlFileFormat.xlCSV);
        xlWbk.Close(SaveChanges: false);
        xlApp.Quit();
    
        // The actual parsing
        using (var parser = new GenericParserAdapter(tempPath)) {
            parser.FirstRowHasHeader = true;
            return parser.GetDataTable();
        }
    
    }
