    CellRange range = excelFile.Worksheets.ActiveWorksheet.GetUsedCellRange(true);
    for (int i = range.FirstColumnIndex; i <= range.LastColumnIndex; i++)
    {
        for (int j = range.FirstRowIndex; j <= range.LastRowIndex; j++)
        {
            ExcelCell cell = range[j - range.FirstRowIndex, i - range.FirstColumnIndex];
            string cellName = CellRange.RowColumnToPosition(j, i);
            string cellRow = ExcelRowCollection.RowIndexToName(j);
            string cellColumn = ExcelColumnCollection.ColumnIndexToName(i);
            Console.WriteLine(string.Format("Cell name: {1}{0}Cell row: {2}{0}Cell column: {3}{0}Cell value: {4}{0}",
                            Environment.NewLine, cellName, cellRow, cellColumn, (cell.Value) ?? "Empty"));
        }
    }
