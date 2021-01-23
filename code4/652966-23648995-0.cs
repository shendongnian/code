            Worksheet worksheet = worksheetPart.Worksheet;
            SheetData sheetData = worksheet.GetFirstChild<SheetData>();
            string cellReference = columnName + rowIndex;
            Alignment alignment1 = new Alignment() { WrapText = true };
            
            // If the worksheet does not contain a row with the specified row index, insert one.
            Row row;
            row = new Row() { RowIndex = 3, StyleIndex = 1 };
            if (sheetData.Elements<Row>().Where(r => r.RowIndex == rowIndex).Count() != 0)
            {
                row = sheetData.Elements<Row>().Where(r => r.RowIndex == rowIndex).First();
            }
            else
            {
                row = new Row() { RowIndex = Convert.ToUInt32(rowIndex) };
                sheetData.Append(row);
            }
            // If there is not a cell with the specified column name, insert one.  
            if (row.Elements<Cell>().Where(c => c.CellReference.Value == columnName + rowIndex).Count() > 0)
            {
                Row row2;
                row2 = new Row() { RowIndex = 3, StyleIndex = 1 };
                Cell rCell = null;
                foreach (Cell celld in row.Elements<Cell>())
                {
                    if (string.Compare(celld.CellReference.Value, "A3", true) > 0)
                    {
                        rCell = celld;
                        break;
                    }
                }
                // Add the cell to the cell table at A1.
                Cell newCell = new Cell() { CellReference = "C3" };
                //Cell newCell1 = new Cell() { CellReference = "D3" };
                row.InsertBefore(newCell, rCell);
                //row.InsertBefore(newCell1, rCell);
                // Set the cell value to be a numeric value of 100.
                newCell.CellValue = new CellValue("#GUIDeXactLCMS#");
                //newCell1.CellValue = new CellValue("EN");
                newCell.DataType = new EnumValue<CellValues>(CellValues.Number);
                return row.Elements<Cell>().Where(c => c.CellReference.Value == cellReference).First();
            }
            else
            {
                // Cells must be in sequential order according to CellReference. Determine where to insert the new cell.
                Cell refCell = null;
                foreach (Cell cell in row.Elements<Cell>())
                {
                    if (string.Compare(cell.CellReference.Value, cellReference, true) > 0)
                    {
                        //string val = cell.CellReference.Value;
                        refCell = cell;
                        break;
                    }
                }
                Cell newCell = new Cell() { CellReference = cellReference };
                row.InsertBefore(newCell, refCell);
                
                return newCell;
                
                
            }
            worksheet.Save();
        }
