    private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex == comboboxColumn.Index && e.RowIndex >= 0) //check if combobox column
        {
            object selectedValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
        }
    }
    
    //changes must be committed as soon as the user changes the drop down box
    private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
    {
        if (dataGridView1.IsCurrentCellDirty)
        {
            dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
    }
