    Console.WriteLine("Creating document");
    using (var spreadsheet = SpreadsheetDocument.Create("output.xlsx", SpreadsheetDocumentType.Workbook))
    {
        Console.WriteLine("Creating workbook");
        spreadsheet.AddWorkbookPart();
        spreadsheet.WorkbookPart.Workbook = new Workbook();
        Console.WriteLine("Creating worksheet");
        var wsPart = spreadsheet.WorkbookPart.AddNewPart<WorksheetPart>();
        wsPart.Worksheet = new Worksheet();
        var stylesPart = spreadsheet.WorkbookPart.AddNewPart<WorkbookStylesPart>();
        stylesPart.Stylesheet = new Stylesheet();
        Console.WriteLine("Creating styles");
        // blank font list
        stylesPart.Stylesheet.Fonts = new Fonts();
        stylesPart.Stylesheet.Fonts.Count = 1;
        stylesPart.Stylesheet.Fonts.AppendChild(new Font());
        // create fills
        stylesPart.Stylesheet.Fills = new Fills();
        
        // create a solid red fill
        var solidRed = new PatternFill() { PatternType = PatternValues.Solid };
        solidRed.ForegroundColor = new ForegroundColor { Rgb = HexBinaryValue.FromString("FFFF0000") }; // red fill
        solidRed.BackgroundColor = new BackgroundColor { Indexed = 64 };
        stylesPart.Stylesheet.Fills.AppendChild(new Fill { PatternFill = new PatternFill { PatternType = PatternValues.None } }); // required, reserved by Excel
        stylesPart.Stylesheet.Fills.AppendChild(new Fill { PatternFill = new PatternFill { PatternType = PatternValues.Gray125 } }); // required, reserved by Excel
        stylesPart.Stylesheet.Fills.AppendChild(new Fill { PatternFill = solidRed });
        stylesPart.Stylesheet.Fills.Count = 3;
        // blank border list
        stylesPart.Stylesheet.Borders = new Borders();
        stylesPart.Stylesheet.Borders.Count = 1;
        stylesPart.Stylesheet.Borders.AppendChild(new Border());
        // blank cell format list
        stylesPart.Stylesheet.CellStyleFormats = new CellStyleFormats();
        stylesPart.Stylesheet.CellStyleFormats.Count = 1;
        stylesPart.Stylesheet.CellStyleFormats.AppendChild(new CellFormat());
        // cell format list
        stylesPart.Stylesheet.CellFormats = new CellFormats();
        // empty one for index 0, seems to be required
        stylesPart.Stylesheet.CellFormats.AppendChild(new CellFormat());
        // cell format references style format 0, font 0, border 0, fill 2 and applies the fill
        stylesPart.Stylesheet.CellFormats.AppendChild(new CellFormat { FormatId = 0, FontId = 0, BorderId = 0, FillId = 2, ApplyFill = true }).AppendChild(new Alignment { Horizontal = HorizontalAlignmentValues.Center });
        stylesPart.Stylesheet.CellFormats.Count = 2;
        stylesPart.Stylesheet.Save();
        Console.WriteLine("Creating sheet data");
        var sheetData = wsPart.Worksheet.AppendChild(new SheetData());
        Console.WriteLine("Adding rows / cells...");
        var row = sheetData.AppendChild(new Row());
        row.AppendChild(new Cell() { CellValue = new CellValue("This"),  DataType = CellValues.String });
        row.AppendChild(new Cell() { CellValue = new CellValue("is"),    DataType = CellValues.String });
        row.AppendChild(new Cell() { CellValue = new CellValue("a"),     DataType = CellValues.String });
        row.AppendChild(new Cell() { CellValue = new CellValue("test."), DataType = CellValues.String });
        sheetData.AppendChild(new Row());
        row = sheetData.AppendChild(new Row());
        row.AppendChild(new Cell() { CellValue = new CellValue("Value:"),   DataType = CellValues.String });
        row.AppendChild(new Cell() { CellValue = new CellValue("123"),      DataType = CellValues.Number });
        row.AppendChild(new Cell() { CellValue = new CellValue("Formula:"), DataType = CellValues.String });
        // style index = 1, i.e. point at our fill format
        row.AppendChild(new Cell() { CellFormula = new CellFormula("B3"),   DataType = CellValues.Number, StyleIndex = 1 });
        Console.WriteLine("Saving worksheet");
        wsPart.Worksheet.Save();
        Console.WriteLine("Creating sheet list");
        var sheets = spreadsheet.WorkbookPart.Workbook.AppendChild(new Sheets());
        sheets.AppendChild(new Sheet() { Id = spreadsheet.WorkbookPart.GetIdOfPart(wsPart), SheetId = 1, Name = "Test" });
        Console.WriteLine("Saving workbook");
        spreadsheet.WorkbookPart.Workbook.Save();
        Console.WriteLine("Done.");
    }
