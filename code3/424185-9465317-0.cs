    public bool CheckIfEmptyCell(xlsSheet, row, column) {
        var cell = (Excel.Range)xlsSheet.Cells[row, column]);
        return (cell.Value2 == null || String.IsNullOrEmpty(cell.Value2.ToString())
    }
    ....
    
    var isEmpty = CheckIfEmptyCell(xlsSheet, 5, "D"); // D5 is empty?
