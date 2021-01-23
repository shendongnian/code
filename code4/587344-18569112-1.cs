    try
            {
                if (dgv_Language.Rows.Count > 2)
                {
                    for (int currentRow = 0; currentRow < dgv_Language.Rows.Count; currentRow++)
                    {
                        var rowToCompare = dgv_Language.Rows[currentRow]; // Get row to compare against other rows
                        // Iterate through all rows 
                        //
                        foreach (DataGridViewRow row in dgv_Language.Rows)
                        {
                            if (rowToCompare.Equals(row))
                            {
                                continue;
                            }
                            // If row is the same row being compared, skip.
                            bool duplicateRow = true;
                            // Compare the value of all cells
                            //
                            if (rowToCompare.Cells[0].Value != null && rowToCompare.Cells[0].Value.ToString() != row.Cells[0].Value.ToString())
                            {
                                duplicateRow = false;
                            }
                            if (duplicateRow)
                            {
                                dgv_Language.Rows.RemoveAt(row.Index);
                                break;
                            }
                        }
                    }
                }
            }
            catch
            {
            }
