    private void GridCellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        //just to be safe
        if (e.RowIndex < 0 || e.ColumnIndex < 0)
        {
            return;
        }
        
        var value = dataGridView1[e.ColumnIndex, e.RowIndex].Value;
    
        if (value != null && value.ToString() == "Yes")  // is completed
        {
           dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Green;
        }
        else
        {
            dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
        }
    }
