    using (SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString))
    {
        using (SqlCommand cmd = new SqlCommand("usp_GetABCD", sqlcon))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
            }
        }
    }
