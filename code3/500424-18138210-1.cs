    private void dataGridViewProduit_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        if ((sender as DataGridView).CurrentCell is DataGridViewCheckBoxCell)
        {
            if (Convert.ToBoolean(((sender as DataGridView).CurrentCell as DataGridViewCheckBoxCell).Value))
            {
                foreach (DataGridViewRow row in (sender as DataGridView).Rows)
                {
                    if (row.Index != (sender as DataGridView).CurrentCell.RowIndex && Convert.ToBoolean(row.Cells[e.ColumnIndex].Value) == true)
                    {
                        row.Cells[e.ColumnIndex].Value = false;
                    }
                }
            }
        }
    }
    private void dataGridViewClient_CurrentCellDirtyStateChanged(object sender, EventArgs e)
    {
        if (this.dataGridViewClient.IsCurrentCellDirty)
        {
            dataGridViewClient.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
    }
