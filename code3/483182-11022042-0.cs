    public String getString(String sql)
    {
        DataSet ds = new DataSet();
        string connstring = String.Format("Server={0};Port={1}; User Id={2};Password={3};Database={4};", tbHost, tbPort, tbUser, tbPass, tbDataBaseName);
        NpgsqlConnection conn = new NpgsqlConnection(connstring);
        conn.Open();
        NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
        ds.Reset();
        try
        {
           da.Fill(ds);          
        }
        catch (Exception msg)
        {
            // do something here or log the error.
        }
        finaly
        {
           if (conn.State.ToString() == "Open")
           {
                conn.Close();
           }
        }
        return ds.Tables.Count == 0 ? "0" : ds.Tables[0].Rows[0][0].ToString();
    }
