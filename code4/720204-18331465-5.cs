    ExcelFile workbook = ExcelFile.Load("Sample.xlsx");
    ExcelWorksheet worksheet = workbook.Worksheets[0];
    
    CellRangeEnumerator enumerator = worksheet.Cells.GetReadEnumerator();
    for (; enumerator.MoveNext();)
    {
        ExcelCell cell = enumerator.Current;
        Console.WriteLine($"Cell value:  {cell.Value ?? "Empty"}");
        Console.WriteLine($"Cell name:   {cell.Name}");
        Console.WriteLine($"Row name:    {cell.Row.Name}");
        Console.WriteLine($"Column name: {cell.Column.Name}");
        Console.WriteLine();
    }
