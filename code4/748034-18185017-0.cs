    public DataTable getDownload(string sql)
    {
        using (SqlConnection con = new SqlConnection(yourconstring))
        {
            SqlDataAdapter dap = new SqlDataAdapter(sql,con);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            return dt;
        }
    }
