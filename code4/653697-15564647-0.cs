    using (SpreadsheetDocument spreadSheet = SpreadsheetDocument.Create(
        System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, SPREADSHEET_NAME),
        SpreadsheetDocumentType.Workbook))
    {
        // create the workbook
        spreadSheet.AddWorkbookPart();
        spreadSheet.WorkbookPart.Workbook = new Workbook ();     // create the worksheet
        spreadSheet.WorkbookPart.AddNewPart<WorksheetPart>();
        spreadSheet.WorkbookPart.WorksheetParts.First().Worksheet = new Worksheet();
    
        // create sheet data
        spreadSheet.WorkbookPart.WorksheetParts.First().Worksheet.AppendChild(new SheetData());
    
        // create row
        spreadSheet.WorkbookPart.WorksheetParts.First().Worksheet.First().AppendChild(new Row());
    
        // create cell with data
        spreadSheet.WorkbookPart.WorksheetParts.First().Worksheet.First().First().AppendChild(          
              new Cell() { CellValue = new CellValue("101") });
    
        // save worksheet
        spreadSheet.WorkbookPart.WorksheetParts.First().Worksheet.Save();
    
        // create the worksheet to workbook relation
        spreadSheet.WorkbookPart.Workbook.AppendChild(new Sheets());
        spreadSheet.WorkbookPart.Workbook.GetFirstChild<Sheets>().AppendChild(new Sheet()
            {
                Id = spreadSheet.WorkbookPart.GetIdOfPart(spreadSheet.WorkbookPart.WorksheetParts.First()),
                SheetId = 1,
                Name = "test"
            });
    
        spreadSheet.WorkbookPart.Workbook.Save();
    }
