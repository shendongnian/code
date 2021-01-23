    public DataTable populateUsingDataAdapter(string myQuery)
    {
        using (SqlConnection con = new SqlConnection(constring))
        {
            SqlDataAdapter dap = new SqlDataAdapter(myQuery,con);
            DataTable dt = new DataTable();
            dap.Fill(ds);
            return dt;
        }
    }
