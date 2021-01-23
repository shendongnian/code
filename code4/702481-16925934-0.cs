    using (SqlConnection c = new SqlConnection("..."))
    {
        c.Open();
        using (SqlCommand cmd = new SqlCommand("INSERT INTO table (...) VALUES (@field1, ...)", c);
        {
            cmd.Parameters.AddWithValue("@field1", "税込");
            cmd.Parameters[0].SqlDbType = SqlDbType.NVarChar;
            cmd.ExecuteNonQuery();
        }
    }
