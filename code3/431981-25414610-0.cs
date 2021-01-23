    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            int iCol = dtg.CurrentCell.ColumnIndex;
            int iRow = dtg.CurrentCell.RowIndex;
            if (keyData == Keys.Enter)
            {
                if (iCol == dtg.ColumnCount - 1)
                {
                    if (iRow + 1 == dtg.RowCount)
                    {
                        dtg.Rows.Add();
                    }
                    dtg.CurrentCell = dtg[0, iRow + 1];
                }
                else
                {
                    dtg.CurrentCell = dtg[iCol + 1, iRow];
                }
                return true;
            }
            else if (keyData == Keys.Escape)
            {
                Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
