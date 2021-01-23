    OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\YOUR_ACCESS_FILE_PATH");
    conn.Open();
    OleDbCommand cmd = new OleDbCommand("SELECT * FROM cartTable WHERE orderNo = " + intOrderNo , conn);
    OleDbDataReader reader = cmd.ExecuteReader();
    DataTable dt = new DataTable();
    dt.Load(reader);
               
    //Bind your grid
    this.gridView1.DataSource = dt;
    this.gridView1.DataBind();
