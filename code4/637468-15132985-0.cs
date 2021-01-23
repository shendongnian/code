    public DataSet GetUsersDataSet()
    {
        SqlConnection con = new SqlConnection(connectionString);
        SqlDataAdapter da = new SqlDataAdapter("SELCT * FROM login", con);
        DataSet ds = new DataSet();
        try
        {
            con.Open(); 
            da.Fill(ds, "login");
            return ds;
        }
        catch 
        { 
           throw new ApplicationException("Data Error:");
        }
        finally { con.Close(); }
    }
