    public DataSet getLogging(DateTime logFrom, DateTime logTo)
    {
        DataSet ds = new DataSet();
        const string sql = "SELECT Columns FROM dbo.Table WHERE LoggedAt BETWEEN @LoggedFrom AND @LoggedTo ... ODRER BY ...";
        using (var mycon = new SqlConnection(connectionString))
        using (var da = new SqlDataAdapter(sql, mycon))
        {
            da.SelectCommand.Parameters.AddWithValue("@LoggedFrom", logFrom);
            da.SelectCommand.Parameters.AddWithValue("@LoggedTo", logFrom);
            try
            {
                da.Fill(ds);
            } catch (Exception f)
            {
                // log here
                throw;
            }
        }
        return ds;
    }
