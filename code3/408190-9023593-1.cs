    using (SqlConnection conn  = new SqlConnection())
    {
        conn.Open();
        Sqlmd.Connection = conn;
        SqlDataAdapter da = new SqlDataAdapter(Sqlmd);
        Dataset ds = new Datasest
        da.Fill(ds)
    }
