    using (SqlConnection conn = new SqlConnection(DatabaseConnectionString))
    {
        conn.Open();
        string sanitized_name;
        using (SqlCommand cmd = new SqlCommand("select quotename(@prmTableToEmpty)", conn))
        {
            cmd.Parameters.Add(new SqlParameter("@prmTableToEmpty", TableToEmpty));
            sanitized_name = (string)cmd.ExecuteScalar();
        }
        using (SqlCommand cmd = new SqlCommand("TRUNCATE TABLE " + sanitized_name, conn))
        {
            cmd.ExecuteNonQuery();
        }
    }
