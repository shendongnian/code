    SqlDataReader dr;
    using (SqlConnection con = ConnectionManager.GetDatabaseConnection())
    {
        SqlCommand cmd = new SqlCommand("getInfo", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@query", SqlDbType.VarChar).Value = sql;
        cmd.Connection = con;
        dr = cmd.ExecuteReader();
    } // the SqlConnection is disposed here
    return dr; // dr is now invalid
