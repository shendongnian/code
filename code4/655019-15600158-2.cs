    string query = "SELECT * from Table1 WHERE ID=?";
      
    OleDbConnection odc = new OleDbConnection(strConn);
    odc.Open();
    OleDbDataAdapter dAdapter = new OleDbDataAdapter();
    OleDbCommand cmd = new OleDbCommand(query,odc);
    cmd.Parameters.Add("?", OleDbType.BSTR, 5).Value ="asdf";
    dAdapter.SelectCommand = cmd;
    ds = new DataSet();
    dAdapter.Fill(ds);
    dataGridView1.DataSource = ds.Tables[0];
