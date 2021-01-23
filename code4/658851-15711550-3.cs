        DataSet ds = new DataSet();
        using(OdbcConnection conn = new OdbcConnection(connectionString))
        {
            conn.Open(); // Open the connection
            string strQuery = "SELECT * FROM ISPINMAS";
            var adapter = new OdbcDataAdapter(strQuery, conn);
            adapter.Fill(ds);
        }
        // At this point the connection is closed and dispose has been called to 
        // free the resources used by the connection
        DataTable dt = ds.Tables[0];
        dataGridView1.DataSource = dt.DefaultView;
        // No need to close the connection here
