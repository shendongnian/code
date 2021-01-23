    string connStr = @"Provider=Microsoft.ACE.OLEDB.12.0;
            Data Source=\\SISC-STRONGHOLD\MIS!\wilbert.beltran\SEEDBucksDbase.accdb";
    string query = "SELECT * From TableAcct";
    using(OleDbConnection conn = new OleDbConnection(connStr))
    {
    	using(OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn))
    	{
    		DataSet ds = new DataSet();
    		adapter.Fill(ds[0]);
    		DataGridView1.DataSource= ds.Tables[0];
    	}
    }
