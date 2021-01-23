    DataTable table = new DataTable();
    table.Columns.Add("Column_Name1", typeof(String));
    table.Columns.Add("Column_Name2", typeof(String));
    ......
    
    foreach (var element in list)
       table.Rows.Add(element.Column_Name1, element.Column_Name2, ...);
    
    dataGridView1.DataSource = table;
    table.DefaultView.RowFilter = "Column_Name1 Like '"+TextBox.Text+"'";
