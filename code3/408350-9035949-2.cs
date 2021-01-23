    word.Table table;
    word.Cell cellTopLeft; //some cell on table.
    word.Cell cellBottomRight; //another cell on table. MUST BE BELOW AND/OR TO THE RIGHT OF cellTopLeft
    int cellTopLeftPosition = (cellTopLeft.RowIndex - 1) * table.Columns.Count + cellTopLeft.ColumnIndex;
    int cellBottomRightPosition = (cellBottomRight.RowIndex - 1) * table.Columns.Count + cellBottomRight.ColumnIndex;
    int stepsToTake = cellBottomRightPosition - cellTopLeftPosition;
    if (stepsToTake > 0 && 
        cellTopLeft.RowIndex <= cellBottomRight.RowIndex && //enforces bottom right cell is actually below of top left cell
        cellTopLeft.ColumnIndex <= cellBottomRight.ColumnIndex) //enforces bottom right cell is actually to the right of top left cell
    {
       word.Range range = cellTopLeft.Range;
       range.MoveEnd(word.WdUnits.wdCell, stepsToTake);
       range.Select();      
    }
