    private void dataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e) 
    {
        if (e.ColumnIndex == 1) 
        {    // NO custom format.
             dataGridView.Rows[e.RowIndex].Cells[1].Style = 
                               new DataGridViewCellStyle() { Format = "#" };
        }
    }
    
    private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e) 
    {
        if (e.ColumnIndex == 1) 
        {    
            dataGridView.Rows[e.RowIndex].Cells[1].Style = 
                              new DataGridViewCellStyle { Format = "#mm" };
        }
    }
