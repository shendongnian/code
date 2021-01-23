    public DataSet getLogging()
    {
        DataSet ds = new DataSet();
        const string sql = "SELECT Columns FROM dbo.Table WHERE ... ODRER BY ...";
        using(var mycon = new SqlConnection(connectionString))
        using(var dataadapter = new SqlDataAdapter(sql, mycon))
        {
            try
            {
                dataadapter.Fill(ds);
            }
            catch (Exception f)
            {
                // log here
                throw;
            }
        }
    }
