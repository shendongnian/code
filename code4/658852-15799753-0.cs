        string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=X:\CMSBak\ISP;Extended Properties=dBASE IV;User ID=Admin;Password=;";
        DataSet ds = new DataSet();
        using(OleDbConnection conn = new OleDbConnection(connectionString))
        {
            conn.Open(); // Open the connection
            string strQuery = "SELECT * FROM ISPINMAS";
            var adapter = new OleDbDataAdapter(strQuery, conn);
            adapter.Fill(ds);
        }
        // At this point the connection is closed and dispose has been called to 
        // free the resources used by the connection
        DataTable dt = ds.Tables[0];
        dataGridView1.DataSource = dt.DefaultView;
        // No need to close the connection here
