    private static int GetRowsInColumnOnWorkSheetInWorkbook(string workbookName, int worksheetNumber, int workSheetColumn)
    {
        return new Excel.Application().Workbooks.Open(workbookName)
            .Sheets[worksheetNumber]
            .UsedRange
            .Columns[workSheetColumn]
            .Rows
            .Count;
    }
