    DataGridView dgv = new DataGridView();
    DataTable table = new DataTable();
    
    dgv.DataSource = table;
    
    table.Columns.Add("Name");
    table.Columns.Add("Color");
    table.Rows.Add("Mike", "blue");
    table.Rows.Add("Pat", "yellow");
    this.Controls.Add(dgv);
