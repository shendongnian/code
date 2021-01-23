    string connectionString = ...
    using (var conn = new SqlConnection(connectionString))
    using (var cmd = conn.CreateCommand())
    {
        conn.Open();
        cmd.CommandText = "SELECT id FROM foo";
        using (var reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                int id = reader.GetInt32(reader.GetOrdinal("id"));
                Console.WriteLine(id);
            }
        }
    }
