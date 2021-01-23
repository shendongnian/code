        private void CopyDataGridViewToClipboard(DataGridView dgv, bool includeHeaders = true, bool allRows = false) 
        {
            // copies the contents of selected/all rows in a data grid view control to clipboard with optional headers
            try
            {
                string s = "";
                DataGridViewColumn oCurrentCol = dgv.Columns.GetFirstColumn(DataGridViewElementStates.Visible);
                if (includeHeaders)
                {                   
                    do
                    {
                        s = s + oCurrentCol.HeaderText + "\t";
                        oCurrentCol = dgv.Columns.GetNextColumn(oCurrentCol, DataGridViewElementStates.Visible, DataGridViewElementStates.None);
                    }
                    while (oCurrentCol != null);
                    s = s.Substring(0, s.Length - 1);
                    s = s + Environment.NewLine;    //Get rows
                }
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    oCurrentCol = dgv.Columns.GetFirstColumn(DataGridViewElementStates.Visible);
                    
                    if (row.Selected || allRows)
                    {
                        do
                        {
                            if (row.Cells[oCurrentCol.Index].Value != null) s = s + row.Cells[oCurrentCol.Index].Value.ToString();
                            s = s + "\t";
                            oCurrentCol = dgv.Columns.GetNextColumn(oCurrentCol, DataGridViewElementStates.Visible, DataGridViewElementStates.None);
                        }
                        while (oCurrentCol != null);
                        s = s.Substring(0, s.Length - 1);
                        s = s + Environment.NewLine;
                    }                                      
                }
                Clipboard.SetText(s);
            }
            catch (Exception ex)
            {
                toolStripStatusLabel2.Text = @"Error: " + ex.Message;
            }
        }
