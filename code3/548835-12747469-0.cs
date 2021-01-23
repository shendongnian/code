    DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();
    column.Name = "Money";
    column.DataSource = new string[] { "10", "30", "80", "100" };
    dataGridView1.Columns.Add(column);
    
    for (int row = 0; row < dataGridView1.Columns.Count; row++)
    {
       DataGridViewComboBoxCell cell = 
           (DataGridViewComboBoxCell)(dataGridView1.Rows[row].Cells["Money"]);
       cell.DataSource = new string[] { "80", "100" };
    }
    
