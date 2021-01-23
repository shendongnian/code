    private void dgv_CurrentCellDirtyStateChanged(object sender, EventArgs e)
    {
        if (dgv.IsCurrentCellDirty && dgv.CurrentCell.OwningColumn.Name == "MyCheckColumn")
            dgv.CommitEdit(DataGridViewDataErrorContexts.Commit);
    }
    private void dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex == -1) //just a guard for the header row
            return;
        if (dgv.Columns[e.ColumnIndex].Name == "MyCheckColumn")
            textBox.Text = dgv.Rows.Cast<DataGridViewRow>().Count(r => Convert.ToBoolean(r.Cells["MyCheckColumn"].Value)).ToString();
    }
