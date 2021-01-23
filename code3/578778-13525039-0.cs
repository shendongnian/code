            private void dgvData_CellFormatting(object sender,
                                        DataGridViewCellFormattingEventArgs e)
            {
                bool inError = false;
    
                // Highlight the row as red if we're in error displaying mode
                if (e.RowIndex >= 0 && fileErrors != null && DisplayErrors)
                {
                    // Add +1 to e.rowindex as errors are using a 1-based index
                    var dataErrors = (from err in fileErrors
                                      where err.LineNumberInError == (e.RowIndex +1)
                                      select err).FirstOrDefault();
                    if (dataErrors != null)
                    {
                        e.CellStyle.BackColor = Color.Red;
                        inError = true;
                    }
                }
    
                // Set all the rows in a column to a colour, depending on it's mapping.
                Color colourToSet = GetBackgroundColourForColumn(dgvData.Columns[e.ColumnIndex].Name);
                if (colourToSet != null && !inError)
                    e.CellStyle.BackColor = colourToSet;
            } 
