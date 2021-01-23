    var startCell = ws.Cells[1, 1];
    int row = 500, col = 500;
    var endCell = ws.Cells[row, col];
    try
    {
        // access range by Property and cells indicating start and end           
        var writeRange = ws.Range[startCell, endCell];
        writeRange.Value = myArray;
    }
    catch (COMException ex)
    {
        Debug.WriteLine(ex.Message);
        Debugger.Break();
    }
