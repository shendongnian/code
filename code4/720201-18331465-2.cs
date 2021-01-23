    ExcelFile workbook = ExcelFile.Load("Sample.xlsx");
    ExcelWorksheet worksheet = workbook.Worksheets[0];
    
    foreach (ExcelRow row in worksheet.Rows)
    {
        foreach (ExcelCell cell in row.AllocatedCells)
        {
            Console.WriteLine($"Cell value:   {cell.Value ?? "Empty"}");
            Console.WriteLine($"Cell name:    {cell.Name}");
            Console.WriteLine($"Row index:    {cell.Row.Index}");
            Console.WriteLine($"Row name:     {cell.Row.Name}");
            Console.WriteLine($"Column index: {cell.Column.Index}");
            Console.WriteLine($"Column name:  {cell.Column.Name}");
            Console.WriteLine();
        }
    }
