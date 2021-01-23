    DataTable dt = new DataTable();
    using (SqlConnection yourConnection = new SqlConnection("connectionstring"))
    {
        SqlCommand cmd = new SqlCommand("....your sql statement", yourConnection);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
    }
