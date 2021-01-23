    private static int _previousClickedCheckBoxRowIndex;
    private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
    {
        var dgv = (DataGridView)sender;
        if ((dgv.IsCurrentCellDirty) & (dgv.CurrentCell.OwningColumn == dgv.Columns["CheckBoxColumn"]))
	    {
		    dgv.CommitEdit(DataGridViewDataErrorContexts.Commit);
	    }
    }
    private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        var dgv = (DataGridView)sender;
        if (dgv.Columns[e.ColumnIndex] == dgv.Columns["CheckBoxColumn"])
        {
            dgv.CellValueChanged -= dataGridView1_CellValueChanged;
            if (_previousClickedCheckBoxRowIndex == e.RowIndex)
            {
                dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value =
                    !((bool)dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                dgv.RefreshEdit();
            }
            else
            {
                dgv.Rows[_previousClickedCheckBoxRowIndex].Cells["CheckBoxColumn"].Value = false;
                _previousClickedCheckBoxRowIndex = e.RowIndex;                               
            }
            dgv.CellValueChanged += dataGridView1_CellValueChanged;
        }
    }
