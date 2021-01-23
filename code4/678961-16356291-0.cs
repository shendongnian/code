    using (var spreadSheet = SpreadsheetDocument.Open(memoryStream, true, openSettings))
    {
    
        var worksheet = GetWorksheet(spreadSheet);
        var worksheetPart = worksheet.WorksheetPart;
        var sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();
    
        Row currentRow;
        Row cloneRow;
        Cell currentCell;
        Cell cloneCell;
    
        // Replace for rows 11 and 9, because they exist after your inserted rows
                    
        currentRow = sheetData.Elements<Row>().FirstOrDefault(r => r.RowIndex == 11);
        cloneRow = (Row)currentRow.CloneNode(true);
        cloneRow.RowIndex += (uint)Items.Count;
        foreach (var child in cloneRow.ChildElements)
        {
            if (child is Cell)
            {
                currentCell = (Cell)child;
                cloneCell = (Cell)currentCell.CloneNode(true);
                // IMPORTANT! this is a very simplistic way of replace something like
                // A11 to A16 (assuming you have 5 rows to insert)
                // A more robust way of replacing is beyond this solution's scope.
                cloneCell.CellReference = cloneCell.CellReference.Value.Replace("11", cloneRow.RowIndex);
                cloneRow.ReplaceChild<Cell>(cloneCell, currentCell);
            }
        }
        sheetData.ReplaceChild<Row>(cloneRow, currentRow);
    
        currentRow = sheetData.Elements<Row>().FirstOrDefault(r => r.RowIndex == 9);
        cloneRow = (Row)currentRow.CloneNode(true);
        cloneRow.RowIndex += (uint)Items.Count;
        foreach (var child in cloneRow.ChildElements)
        {
            if (child is Cell)
            {
                currentCell = (Cell)child;
                cloneCell = (Cell)currentCell.CloneNode(true);
                cloneCell.CellReference = cloneCell.CellReference.Value.Replace("9", cloneRow.RowIndex);
                cloneRow.ReplaceChild<Cell>(cloneCell, currentCell);
            }
        }
        sheetData.ReplaceChild<Row>(cloneRow, currentRow);
    
        var newRowIndex = 8;
        foreach (var item in Items)
        {
            newRowIndex++;
    
            var newRow = new Row()
            {
                RowIndex = (uint)newRowIndex
            };
            var lastRow = sheetData.Elements<Row>().LastOrDefault(l => l.RowIndex == newRowIndex - 1);
    
            sheetData.InsertAfter(newRow, lastRow);
        }
    
        worksheet.Save();
    }
