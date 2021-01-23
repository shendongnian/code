    private static int GetRowsInColumnOnWorkSheetInWorkbook(string workbookName, string worksheetName, int workSheetColumn)
    {
        return new Excel.Application().Workbooks.Open(workbookName)
            .Sheets[worksheetName]
            .UsedRange
            .Columns[workSheetColumn]
            .Rows
            .Count;
    }
