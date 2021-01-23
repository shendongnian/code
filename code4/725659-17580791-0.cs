    private ExcelRange GetLastContiguousCell(ExcelRange beginCell)
    {
        var worksheet = beginCell.Worksheet;
        var beginCellAddress = new ExcelCellAddress(beginCell.Start.Row, beginCell.Start.Column);
        var lastCellAddress = worksheet.Dimension.End;
        var bottomCell = worksheet.Cells[beginCellAddress.Row, beginCellAddress.Column, lastCellAddress.Row, beginCellAddress.Column]
            .First(cell => cell.Offset(1, 0).Value == null);
        var rightCell = worksheet.Cells[beginCellAddress.Row, beginCellAddress.Column, beginCellAddress.Row, lastCellAddress.Column]
            .First(cell => cell.Offset(0, 1).Value == null);
        return worksheet.Cells[bottomCell.Start.Row, rightCell.Start.Column];
    }
