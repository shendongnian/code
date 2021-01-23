    using (SqlConnection cnn = new SqlConnection(sqlConString))
    {
        using (SqlCommand cmd = new SqlCommand(File.ReadAllText(dbPath), cnn))
        {
            cnn.Open();
            cmd.ExecuteNonQuery();
        }
    }
