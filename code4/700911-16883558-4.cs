    DataTable dt = new DataTable();
    dt.Columns.Add("Email Address");
    
    dt.Rows.Add(new object[] { "def@gmail.com" });
    dt.Rows.Add(new object[] { "def@gmail.com" });
    dt.Rows.Add(new object[] { "def@gmail.com" });
    dataGridView1.DataSource = dt;
    dataGridView1.Show();
