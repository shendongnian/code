    DataTable dt = new DataTable();
    using (SqlConnection yourConnection = new SqlConnection("connectionstring"))
    {
        using (SqlCommand cmd = new SqlCommand("....your sql statement", yourConnection))
        {
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                da.Fill(dt);
            }
        }
    }
