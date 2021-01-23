    DataGridViewSelectedRowCollection selected;
    private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
    {
        DataGridView dgv = (DataGridView)sender;
        DataGridViewCell cell = dgv.CurrentCell;
        if (cell.RowIndex >= 0 && cell.ColumnIndex == 1) // My checkbox column
        {
            // If checkbox value changed, copy it's value to all selectedrows
            bool checkvalue = false;
            if (dgv.Rows[cell.RowIndex].Cells[cell.ColumnIndex].EditedFormattedValue != null && dgv.Rows[cell.RowIndex].Cells[cell.ColumnIndex].EditedFormattedValue.Equals(true))
                checkvalue = true;
            
            for (int i=0; i<selected.Count; i++)
                dgv.Rows[selected[i].Index].Cells[1].Value = checkvalue;
        }
        
        dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
    }
    
    private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
    {
        selected = dataGridView1.SelectedRows;
    }
