    public CellFormat GetCellFormat(WorkbookPart workbookPart, uint styleIndex)
    {
        return workbookPart.WorkbookStylesPart.Stylesheet.Elements<CellFormats>().First().Elements<CellFormat>().ElementAt((int)styleIndex);
    }
    public uint InsertCellFormat(WorkbookPart workbookPart, CellFormat cellFormat)
    {
        CellFormats cellFormats = workbookPart.WorkbookStylesPart.Stylesheet.Elements<CellFormats>().First();
        cellFormats.Append(cellFormat);
        return (uint)cellFormats.Count++;
    }
