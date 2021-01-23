        SqlDataAdapter adapter = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand("usp_GetABCD", sqlcon);
        cmd.CommandType = CommandType.StoredProcedure;
        DataTable dt = new DataTable();
        adapter.Fill(dt);
