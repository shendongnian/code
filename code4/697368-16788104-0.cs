    OracleDataAdapter _dataAdapter = null;
    
    public void FillDataGridView(string conString, string selectCmd, string tableName)
    {
       using(OracleConnection con = new OracleConnection(conString))
       {
           _dataAdapter = new OracleDataAdapter();
           _dataAdapter.SelectCommand = new OracleCommand(selectCmd, con);
           OracleCommandBuilder cb = new OracleCommandBuilder(_dataAdapter);
           con.Open();
           DataSet ds = new DataSet();
           _adapter.Fill(ds, tableName);
           dataGridView1.DataSource = ds.Tables[0];
       }
    }
