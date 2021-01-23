    ExcelFile workbook = ExcelFile.Load("Sample.xlsx");
    ExcelWorksheet worksheet = workbook.Worksheets[0];
    
    CellRange range = worksheet.GetUsedCellRange(true);
    for (int r = range.FirstRowIndex; r <= range.LastRowIndex; r++)
    {
        for (int c = range.FirstColumnIndex; c <= range.LastColumnIndex; c++)
        {
            ExcelCell cell = range[r - range.FirstRowIndex, c - range.FirstColumnIndex];
    
            string cellName = CellRange.RowColumnToPosition(r, c);
            string cellRow = ExcelRowCollection.RowIndexToName(r);
            string cellColumn = ExcelColumnCollection.ColumnIndexToName(c);
    
            Console.WriteLine(string.Format("Cell name: {1}{0}Cell row: {2}{0}Cell column: {3}{0}Cell value: {4}{0}",
                Environment.NewLine, cellName, cellRow, cellColumn, (cell.Value) ?? "Empty"));
        }
    }
