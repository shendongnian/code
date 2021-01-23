    public static void Main()
    {
        using (WordprocessingDocument wDoc = WordprocessingDocument.Open(@"D:\test.docx", true))
        {
            Stream stream = wDoc.MainDocumentPart.ChartParts.First().EmbeddedPackagePart.GetStream();
            using (SpreadsheetDocument ssDoc = SpreadsheetDocument.Open(stream, true))
            {
                WorkbookPart wbPart = ssDoc.WorkbookPart;
                Sheet theSheet = wbPart.Workbook.Descendants<Sheet>().
                  Where(s => s.Name == "Sheet1").FirstOrDefault();
                if (theSheet != null)
                {
                    Worksheet ws = ((WorksheetPart)(wbPart.GetPartById(theSheet.Id))).Worksheet;
                    Cell theCell = InsertCellInWorksheet("C", 2, ws);
                    theCell.CellValue = new CellValue("5");
                    theCell.DataType = new EnumValue<CellValues>(CellValues.Number);
                    ws.Save();
                }
            }
        }
    }
    private static Cell InsertCellInWorksheet(string columnName, uint rowIndex, Worksheet worksheet)
    {
        SheetData sheetData = worksheet.GetFirstChild<SheetData>();
        string cellReference = columnName + rowIndex;
        Row row;
        if (sheetData.Elements<Row>().Where(r => r.RowIndex == rowIndex).Count() != 0)
        {
            row = sheetData.Elements<Row>().Where(r => r.RowIndex == rowIndex).First();
        }
        else
        {
            row = new Row() { RowIndex = rowIndex };
            sheetData.Append(row);
        }
        if (row.Elements<Cell>().Where(c => c.CellReference.Value == columnName + rowIndex).Count() > 0)
        {
            return row.Elements<Cell>().Where(c => c.CellReference.Value == cellReference).First();
        }
        else
        {
            Cell refCell = null;
            foreach (Cell cell in row.Elements<Cell>())
            {
                if (string.Compare(cell.CellReference.Value, cellReference, true) > 0)
                {
                    refCell = cell;
                    break;
                }
            }
            Cell newCell = new Cell() { CellReference = cellReference };
            row.InsertBefore(newCell, refCell);
            worksheet.Save();
            return newCell;
        }
    }
