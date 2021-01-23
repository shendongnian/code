    private void dataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
    {    
          dataGridView1.EndEdit();
    }
    private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        if(e.ColumnIndex == 0)//Just care the first column
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
    }
