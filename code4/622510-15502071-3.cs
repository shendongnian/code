    int iFirstRowIndex = table.DataRange.FirstRow;
    int iFirstColumnIndex = table.DataRange.FirstColumn;
    int iLastRowIndex = table.DataRange.RowCount + iFirstRowIndex;
    int iLastColumnIndex = table.DataRange.ColumnCount + iFirstColumnIndex;
    
    for (int rowIndex = 0; rowIndex < table.DataRange.RowCount; rowIndex++)
    {
         //Get last cell in every row of table
         Cell cell = worksheet.Cells.EndCellInColumn(rowIndex + iFirstRowIndex, rowIndex + iFirstRowIndex, (short)iFirstColumnIndex, (short)(iLastColumnIndex - 1));
         //display cell value
         System.Console.WriteLine(cell.Value);
    }
