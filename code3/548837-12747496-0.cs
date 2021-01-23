    var table = new DataTable();
    table.Columns.Add("Name", typeof(string));
    table.Columns.Add("Money", typeof(string));
    table.Rows.Add("Hi", "100");
    table.Rows.Add("Ki", "30");
    var column = new DataGridViewComboBoxColumn();
    column.DataSource = new List<string>() { "10", "30", "80", "100" };            
            
    dataGridView1.Columns.Add(column);
    dataGridView1.DataSource = table;
