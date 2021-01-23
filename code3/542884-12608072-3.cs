    using (FileStream file = new FileStream("c:\\temp\\secure.xlsx", 
           FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite))
    {
      using (ExcelPackage ep = new ExcelPackage(file, "P@$$W0rd"))
      {     
        using (SpreadsheetDocument sd = SpreadsheetDocument.Open(ep.Package))
        {
          WorkbookPart workbookPart = sd.WorkbookPart;
          WorksheetPart worksheetPart = workbookPart.WorksheetParts.Last();
          SheetData sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();
          var row = sheetData.Elements<Row>().FirstOrDefault();
          var cell = row.Elements<Cell>().FirstOrDefault();
          Console.Out.WriteLine(cell.CellValue.InnerText);
        }
      }
    }
