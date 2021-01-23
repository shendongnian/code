    List<object> obj = new List<object>();
    DataTable dt = new DataTable();
    dt.Columns.Add("ID");
    dt.Columns.Add("Name");
    dt.Rows.Add("1", "AAA");
    dt.Rows.Add("2", "BBB");
    dt.Rows.Add("3", "CCC");
    dataGridView1.DataSource = dt; // THIS IS ALL U NEED! Just bind the DataTable to the grid as data source!
