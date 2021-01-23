    int Count = 0;
    using (SqlCommand cmd1 = new SqlCommand("Exists", conn))
    {
        cmd1.CommandType = CommandType.StoredProcedure;
        cmd1.Parameters.Add(new SqlParameter("@Url", URL));
        using (SqlDataReader rdr1 = cmd1.ExecuteReader())
        {
            if (rdr1.Read())
            {
                Count++;
            }
        }
    }
