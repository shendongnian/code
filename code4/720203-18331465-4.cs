    int rowCount = worksheet.Rows.Count;
    
    for (int r = 0; r < rowCount; r++)
    {
        ExcelRow row = worksheet.Rows[r];
        int columnCount = row.AllocatedCells.Count;
    
        for (int c = 0; c < columnCount; c++)
        {
            ExcelCell cell = row.Cells[c];
    
            // ...
        }
    }
