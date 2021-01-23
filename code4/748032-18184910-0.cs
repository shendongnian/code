    private DataTable getDownload(string sql)
    {
        SqlDataReader dr;
        DataTable dt;
        using (SqlConnection con = ConnectionManager.GetDatabaseConnection())
        {
            SqlCommand cmd = new SqlCommand("getInfo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@query", SqlDbType.VarChar).Value = sql;
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(dr);
        }
        return dt;
    }
