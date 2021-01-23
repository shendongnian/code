    using (var conn = new SQLiteConnection(@"Data Source=test.db3"))
    using (var cmd = conn.CreateCommand())
    {
        conn.Open();
        cmd.CommandText = "SELECT id FROM foo";
        using (var reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                int id = reader.GetInt32(reader.GetOrdinal("id"));
                ...
            }
        }
    }
