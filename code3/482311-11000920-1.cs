    string filePath = "workbook.xlsx";
    string sheetName = "Sheet1";
    uint startRow = 9;
    string columnName = "C";
    string[] data = new string[] { "A", "B", "C" };
    using (var spreadsheetDocument = SpreadsheetDocument.Open(filePath, true))
    {
        // Find the Id of the worksheet in question
        var sheet = spreadsheetDocument.WorkbookPart.Workbook
            .Sheets.Elements<Sheet>()
            .Where(s => s.Name == sheetName).First();
        var sheetReferenceId = sheet.Id;
        // Map the Id to the worksheet part
        WorksheetPart worksheetPart = (WorksheetPart)spreadsheetDocument.WorkbookPart.GetPartById(sheetReferenceId);
        var sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();
        // Inset the data at the given location
        for (uint i = 0; i < data.Length; i++)
        {
            uint rowNumber = startRow + i;
            // Find the XML entry for row i
            var row = sheetData.Elements<Row>().Where(r => r.RowIndex == rowNumber).FirstOrDefault();
            if (row == null)
            {
                // Row does not exist yet, create it
                row = new Row();
                row.RowIndex = rowNumber;
                // Insert the row at its correct sequential position
                Row rowAfter = null;
                foreach (Row otherRow in sheetData.Elements<Row>())
                {
                    if (otherRow.RowIndex > row.RowIndex)
                    {
                        rowAfter = otherRow;
                        break;
                    }
                }
                if (rowAfter == null)
                    // New row is the last row in the sheet
                    sheetData.Append(row);
                else
                    sheetData.InsertBefore(row, rowAfter);
            }
            // CellReferences in OpenXML are "normal" Excel cell references, e.g. D15
            string cellReference = columnName + rowNumber.ToString();
            // Find cell in row
            var cell = row.Elements<Cell>()
                .Where(c => c.CellReference == cellReference)
                .FirstOrDefault();
            if (cell == null)
            {
                // Cell does not exist yet, create it
                cell = new Cell();
                cell.CellReference = new StringValue(cellReference);
                // The cell must be in the correct position (e.g. column B after A)
                // Note: AA must be after Z, so a normal string compare is not sufficient
                Cell cellAfter = null;
                foreach (Cell otherCell in row.Elements<Cell>())
                {
                    // This is ugly, but somehow the row number must be stripped from the
                    // cell reference for comparison
                    string otherCellColumn = otherCell.CellReference.Value;
                    otherCellColumn = otherCellColumn.Remove(otherCellColumn.Length - rowNumber.ToString().Length);
                            
                    // Now compare first to length and then alphabetically
                    if (otherCellColumn.Length > columnName.Length ||
                        string.Compare(otherCellColumn, columnName, true) > 0)
                    {
                        cellAfter = otherCell;
                        break;
                    }
                }
                if (cellAfter == null)
                    // New cell is last cell in row
                    row.Append(cell);
                else
                    row.InsertBefore(cell, cellAfter);
            }
            // Note: This is the most simple approach.
            //       Normally Excel itself will store the string as a SharedString,
            //       which is more difficult to implement. The only drawback of using
            //       this approach though, is that the cell might have been the only
            //       reference to its shared string value, which is not deleted from the
            //       list here.
            cell.DataType = CellValues.String;
            cell.CellValue = new CellValue(data[i]);
        }
    }
