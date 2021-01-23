    ExcelFile workbook = ExcelFile.Load("Sample.xlsx");
    ExcelWorksheet worksheet = workbook.Worksheets[0];
    
    int rowCount = worksheet.Rows.Count;
    int columnCount = worksheet.CalculateMaxUsedColumns();
    
    for (int r = 0; r < rowCount; r++)
    {
        for (int c = 0; c < columnCount; c++)
        {
            ExcelCell cell = worksheet.Cells[r, c];
            Console.WriteLine($"Cell value:  {cell.Value ?? "Empty"}");
            Console.WriteLine($"Cell name:   {cell.Name}");
            Console.WriteLine($"Row name:    {cell.Row.Name}");
            Console.WriteLine($"Column name: {cell.Column.Name}");
            Console.WriteLine();
        }
    }
