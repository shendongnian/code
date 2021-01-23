        /// <summary>
        /// Updates all of the Row indexes and the child Cells' CellReferences whenever
        /// a row is inserted or deleted.
        /// </summary>
        /// <param name="worksheetPart">Worksheet Part</param>
        /// <param name="rowIndex">Row Index being inserted or deleted</param>
        /// <param name="isDeletedRow">True if row was deleted, otherwise false</param>
        private static void UpdateRowIndexes(WorksheetPart worksheetPart, uint rowIndex, bool isDeletedRow)
        {
            // Get all the rows in the worksheet with equal or higher row index values than the one being inserted/deleted for reindexing.
            IEnumerable<Row> rows = worksheetPart.Worksheet.Descendants<Row>().Where(r => r.RowIndex.Value >= rowIndex);
    
            foreach (Row row in rows)
            {
                uint newIndex = (isDeletedRow ? row.RowIndex - 1 : row.RowIndex + 1);
                string curRowIndex = row.RowIndex.ToString();
                string newRowIndex = newIndex.ToString();
    
                foreach (Cell cell in row.Elements<Cell>())
                {
                    // Update the references for the rows cells.
                    cell.CellReference = new StringValue(cell.CellReference.Value.Replace(curRowIndex, newRowIndex));
                }
    
                // Update the row index.
                row.RowIndex = newIndex;
            }
        }
             /// <summary>
            /// Updates the MergedCelss reference whenever a new row is inserted or deleted. It will simply take the
            /// row index and either increment or decrement the cell row index in the merged cell reference based on
            /// if the row was inserted or deleted.
            /// </summary>
            /// <param name="worksheetPart">Worksheet Part</param>
            /// <param name="rowIndex">Row Index being inserted or deleted</param>
            /// <param name="isDeletedRow">True if row was deleted, otherwise false</param>
            private static void UpdateMergedCellReferences(WorksheetPart worksheetPart, uint rowIndex, bool isDeletedRow)
            {
                if (worksheetPart.Worksheet.Elements<MergeCells>().Count() > 0)
                {
                    MergeCells mergeCells = worksheetPart.Worksheet.Elements<MergeCells>().FirstOrDefault();
    
                    if (mergeCells != null)
                    {
                        // Grab all the merged cells that have a merge cell row index reference equal to or greater than the row index passed in
                        List<MergeCell> mergeCellsList = mergeCells.Elements<MergeCell>().Where(r => r.Reference.HasValue)
                                                                                         .Where(r => GetRowIndex(r.Reference.Value.Split(':').ElementAt(0)) >= rowIndex ||
                                                                                                     GetRowIndex(r.Reference.Value.Split(':').ElementAt(1)) >= rowIndex).ToList();
    
                        // Need to remove all merged cells that have a matching rowIndex when the row is deleted
                        if (isDeletedRow)
                        {
                            List<MergeCell> mergeCellsToDelete = mergeCellsList.Where(r => GetRowIndex(r.Reference.Value.Split(':').ElementAt(0)) == rowIndex ||
                                                                                           GetRowIndex(r.Reference.Value.Split(':').ElementAt(1)) == rowIndex).ToList();
    
                            // Delete all the matching merged cells
                            foreach (MergeCell cellToDelete in mergeCellsToDelete)
                            {
                                cellToDelete.Remove();
                            }
    
                            // Update the list to contain all merged cells greater than the deleted row index
                            mergeCellsList = mergeCells.Elements<MergeCell>().Where(r => r.Reference.HasValue)
                                                                             .Where(r => GetRowIndex(r.Reference.Value.Split(':').ElementAt(0)) > rowIndex ||
                                                                                         GetRowIndex(r.Reference.Value.Split(':').ElementAt(1)) > rowIndex).ToList();
                        }
    
                        // Either increment or decrement the row index on the merged cell reference
                        foreach (MergeCell mergeCell in mergeCellsList)
                        {
                            string[] cellReference = mergeCell.Reference.Value.Split(':');
    
                            if (GetRowIndex(cellReference.ElementAt(0)) >= rowIndex)
                            {
                                string columnName = GetColumnName(cellReference.ElementAt(0));
                                cellReference[0] = isDeletedRow ? columnName + (GetRowIndex(cellReference.ElementAt(0)) - 1).ToString() : IncrementCellReference(cellReference.ElementAt(0), CellReferencePartEnum.Row);
                            }
    
                            if (GetRowIndex(cellReference.ElementAt(1)) >= rowIndex)
                            {
                                string columnName = GetColumnName(cellReference.ElementAt(1));
                                cellReference[1] = isDeletedRow ? columnName + (GetRowIndex(cellReference.ElementAt(1)) - 1).ToString() : IncrementCellReference(cellReference.ElementAt(1), CellReferencePartEnum.Row);
                            }
    
                            mergeCell.Reference = new StringValue(cellReference[0] + ":" + cellReference[1]);
                        }
                    }
                }
            }
            /// <summary>
            /// Updates all hyperlinks in the worksheet when a row is inserted or deleted.
            /// </summary>
            /// <param name="worksheetPart">Worksheet Part</param>
            /// <param name="rowIndex">Row Index being inserted or deleted</param>
            /// <param name="isDeletedRow">True if row was deleted, otherwise false</param>
            private static void UpdateHyperlinkReferences(WorksheetPart worksheetPart, uint rowIndex, bool isDeletedRow)
            {
                Hyperlinks hyperlinks = worksheetPart.Worksheet.Elements<Hyperlinks>().FirstOrDefault();
    
                if (hyperlinks != null)
                {
                    Match hyperlinkRowIndexMatch;
                    uint hyperlinkRowIndex;
    
                    foreach (Hyperlink hyperlink in hyperlinks.Elements<Hyperlink>())
                    {
                        hyperlinkRowIndexMatch = Regex.Match(hyperlink.Reference.Value, "[0-9]+");
                        if (hyperlinkRowIndexMatch.Success && uint.TryParse(hyperlinkRowIndexMatch.Value, out hyperlinkRowIndex) && hyperlinkRowIndex >= rowIndex)
                        {
                            // if being deleted, hyperlink needs to be removed or moved up
                            if (isDeletedRow)
                            {
                                // if hyperlink is on the row being removed, remove it
                                if (hyperlinkRowIndex == rowIndex)
                                {
                                    hyperlink.Remove();
                                }
                                // else hyperlink needs to be moved up a row
                                else{
                                    hyperlink.Reference.Value = hyperlink.Reference.Value.Replace(hyperlinkRowIndexMatch.Value, (hyperlinkRowIndex - 1).ToString());
                                
                                }
                            }
                            // else row is being inserted, move hyperlink down
                            else
                            {
                                hyperlink.Reference.Value = hyperlink.Reference.Value.Replace(hyperlinkRowIndexMatch.Value, (hyperlinkRowIndex + 1).ToString());
                            }
                        }
                    }
    
                    // Remove the hyperlinks collection if none remain
                    if (hyperlinks.Elements<Hyperlink>().Count() == 0)
                    {
                        hyperlinks.Remove();
                    }
                }
            }
            /// <summary>
            /// Given a cell name, parses the specified cell to get the row index.
            /// </summary>
            /// <param name="cellReference">Address of the cell (ie. B2)</param>
            /// <returns>Row Index (ie. 2)</returns>
            public static uint GetRowIndex(string cellReference)
            {
                // Create a regular expression to match the row index portion the cell name.
                Regex regex = new Regex(@"\d+");
                Match match = regex.Match(cellReference);
    
                return uint.Parse(match.Value);
            }
            /// <summary>
            /// Increments the reference of a given cell.  This reference comes from the CellReference property
            /// on a Cell.
            /// </summary>
            /// <param name="reference">reference string</param>
            /// <param name="cellRefPart">indicates what is to be incremented</param>
            /// <returns></returns>
            public static string IncrementCellReference(string reference, CellReferencePartEnum cellRefPart)
            {
                string newReference = reference;
    
                if (cellRefPart != CellReferencePartEnum.None && !String.IsNullOrEmpty(reference))
                {
                    string[] parts = Regex.Split(reference, "([A-Z]+)");
    
                    if (cellRefPart == CellReferencePartEnum.Column || cellRefPart == CellReferencePartEnum.Both)
                    {
                        List<char> col = parts[1].ToCharArray().ToList();
                        bool needsIncrement = true;
                        int index = col.Count - 1;
    
                        do
                        {
                            // increment the last letter
                            col[index] = Letters[Letters.IndexOf(col[index]) + 1];
    
                            // if it is the last letter, then we need to roll it over to 'A'
                            if (col[index] == Letters[Letters.Count - 1])
                            {
                                col[index] = Letters[0];
                            }
                            else
                            {
                                needsIncrement = false;
                            }
    
                        } while (needsIncrement && --index >= 0);
    
                        // If true, then we need to add another letter to the mix. Initial value was something like "ZZ"
                        if (needsIncrement)
                        {
                            col.Add(Letters[0]);
                        }
    
                        parts[1] = new String(col.ToArray());
                    }
    
                    if (cellRefPart == CellReferencePartEnum.Row || cellRefPart == CellReferencePartEnum.Both)
                    {
                        // Increment the row number. A reference is invalid without this componenet, so we assume it will always be present.
                        parts[2] = (int.Parse(parts[2]) + 1).ToString();
                    }
    
                    newReference = parts[1] + parts[2];
                }
    
                return newReference;
            }
