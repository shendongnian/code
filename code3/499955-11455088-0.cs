            /// <summary>
            /// Inserts a new row at the desired index. If one already exists, then it is
            /// returned. If an insertRow is provided, then it is inserted into the desired
            /// rowIndex
            /// </summary>
            /// <param name="rowIndex">Row Index</param>
            /// <param name="worksheetPart">Worksheet Part</param>
            /// <param name="insertRow">Row to insert</param>
            /// <param name="isLastRow">Optional parameter - True, you can guarantee that this row is the last row (not replacing an existing last row) in the sheet to insert; false it is not</param>
            /// <returns>Inserted Row</returns>
            public static Row InsertRow(uint rowIndex, WorksheetPart worksheetPart, Row insertRow, bool isNewLastRow = false)
            {
                Worksheet worksheet = worksheetPart.Worksheet;
                SheetData sheetData = worksheet.GetFirstChild<SheetData>();
    
                Row retRow = !isNewLastRow ? sheetData.Elements<Row>().FirstOrDefault(r => r.RowIndex == rowIndex) : null;
    
                // If the worksheet does not contain a row with the specified row index, insert one.
                if (retRow != null)
                {
                    // if retRow is not null and we are inserting a new row, then move all existing rows down.
                    if (insertRow != null)
                    {
                        UpdateRowIndexes(worksheetPart, rowIndex, false);
                        UpdateMergedCellReferences(worksheetPart, rowIndex, false);
                        UpdateHyperlinkReferences(worksheetPart, rowIndex, false);
    
                        // actually insert the new row into the sheet
                        retRow = sheetData.InsertBefore(insertRow, retRow);  // at this point, retRow still points to the row that had the insert rowIndex
    
                        string curIndex = retRow.RowIndex.ToString();
                        string newIndex = rowIndex.ToString();
    
                        foreach (Cell cell in retRow.Elements<Cell>())
                        {
                            // Update the references for the rows cells.
                            cell.CellReference = new StringValue(cell.CellReference.Value.Replace(curIndex, newIndex));
                        }
    
                        // Update the row index.
                        retRow.RowIndex = rowIndex;
                    }
                }
                else
                {
                    // Row doesn't exist yet, shifting not needed.
                    // Rows must be in sequential order according to RowIndex. Determine where to insert the new row.
                    Row refRow = !isNewLastRow ? sheetData.Elements<Row>().FirstOrDefault(row => row.RowIndex > rowIndex) : null;
    
                    // use the insert row if it exists
                    retRow = insertRow ?? new Row() { RowIndex = rowIndex };
    
                    IEnumerable<Cell> cellsInRow = retRow.Elements<Cell>();
    
                    if (cellsInRow.Any())
                    {
                        string curIndex = retRow.RowIndex.ToString();
                        string newIndex = rowIndex.ToString();
    
                        foreach (Cell cell in cellsInRow)
                        {
                            // Update the references for the rows cells.
                            cell.CellReference = new StringValue(cell.CellReference.Value.Replace(curIndex, newIndex));
                        }
    
                        // Update the row index.
                        retRow.RowIndex = rowIndex;
                    }
    
                    sheetData.InsertBefore(retRow, refRow);
                }
    
                return retRow;
            }
