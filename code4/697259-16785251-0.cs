    private void GridCellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.ColumnIndex < 0)
        {
            return;
        }
        
        if (dataGridView1.Columns[e.ColumnIndex].Name == "EDIT")
        {
            //edit logic here
        }
        else if (dataGridView1.Columns[e.ColumnIndex].Name == "DELETE")
        {
            //delete logic here
        }
    }
