    Cell cell = GetCell(worksheetPart.Worksheet, columnName, rowIndex);
    cell.StyleIndex = InsertCellFormat(workbookPart, GenerateCellFormat());
    // Helper method to insert the cell format in the CellFormats
    public static uint InsertCellFormat(WorkbookPart workbookPart, CellFormat cellFormat)
    {
        CellFormats cellFormats = workbookPart.WorkbookStylesPart.Stylesheet.Elements<CellFormats>().First();
        cellFormats.Append(cellFormat);
        return (uint)cellFormats.Count++;
    }
