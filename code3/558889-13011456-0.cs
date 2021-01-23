    private void dataGridView1_CellClick(object sender,
        DataGridViewCellEventArgs e)
    {
        // here you can have column reference by using e.ColumnIndex
        DataGridViewImageCell cell = (DataGridViewImageCell)
            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
        
        // ... do something ...
    }
