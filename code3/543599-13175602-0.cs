    public static void FlushCachedValues(SpreadsheetDocument doc)
    {
       doc.WorkbookPart.WorksheetParts
          .SelectMany(part => part.Worksheet.Elements<SheetData>())
          .SelectMany(data => data.Elements<Row>())
          .SelectMany(row => row.Elements<Cell>())
          .Where(cell => cell.CellFormula != null && cell.CellValue != null)
          .ToList()
          .ForEach(cell => cell.CellValue.Remove());
     }
