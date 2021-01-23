    private void GridCellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.ColumnIndex < 0)
        {
            return;
        }
    
        if (dataGridView1[e.ColumnIndex, e.RowIndex] is DataGridViewCheckBoxCell)
        {
            var check = (dataGridView1[e.ColumnIndex, e.RowIndex].Value as bool?) ?? false;
            
            if (check)
            {
                //checked
            }
        }
    }
