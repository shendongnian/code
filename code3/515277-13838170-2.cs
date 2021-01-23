    private void dgvStandingOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (dgvStandingOrder.Columns[e.ColumnIndex].Name == "IsSelected" && dgvStandingOrder.CurrentCell is DataGridViewCheckBoxCell)
        {
            bool isChecked = (bool)dgvStandingOrder[e.ColumnIndex, e.RowIndex].EditedFormattedValue;
            if (isChecked == false)
            {
                dgvStandingOrder.Rows[e.RowIndex].Cells["Status"].Value = "";
            }
            dgvStandingOrder.EndEdit();
        }
    }
    
    private void dgvStandingOrder_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
    
        dgvStandingOrder.CommitEdit(DataGridViewDataErrorContexts.Commit);
    }
    
    private void dgvStandingOrder_CurrentCellDirtyStateChanged(object sender, EventArgs e)
    {
        if (dgvStandingOrder.CurrentCell is DataGridViewCheckBoxCell)
        {
            dgvStandingOrder.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
    }
