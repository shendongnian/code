    Worksheet worksheet = Application.Sheets[2]; //Index of the sheet you want to change the selected cell on
    
    if (worksheet == Application.ActiveSheet)
    {
        Excel.Range range = worksheet.UsedRange;
    
        int rows = range.Rows.Count;
        int columns = range.Columns.Count;
    
        Excel.Range activeCell = worksheet.Cells[rows, columns];
        activeCell.Select();
    }
