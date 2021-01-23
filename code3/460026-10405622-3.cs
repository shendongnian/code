    DataTable tvp = new DataTable();
    // define / populate DataTable
    
    using (connectionObject)
    {
        SqlCommand cmd = new SqlCommand("dbo.InsertMyDataTable", connectionObject);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlParameter tvparam = cmd.Parameters.AddWithValue("@dt", tvp);
        tvparam.SqlDbType = SqlDbType.Structured;
        cmd.ExecuteNonQuery();
    }
