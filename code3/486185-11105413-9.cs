    DataTable tvp = new DataTable();
    // define / populate DataTable from your List here
    
    using (conn)
    {
        SqlCommand cmd = new SqlCommand("dbo.DoSomethingWithEmployees", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlParameter tvparam = cmd.Parameters.AddWithValue("@List", tvp);
        tvparam.SqlDbType = SqlDbType.Structured;
        // execute query, consume results, etc. here
    }
