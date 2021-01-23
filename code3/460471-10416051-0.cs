    public IEnumerable<Test> GetTests()
    {
        using (var conn = new SqlConnection(connectionString))
        using (var cmd = conn.CreateCommand())
        {
            conn.Open();
            cmd.CommandText = "SELECT ID, name FROM Test";
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    yield return new Test
                    {
                        ID = reader.GetInt32(reader.GetOrdinal("ID")),
                        name = reader.GetString(reader.GetOrdinal("name")),
                    }
                };
            }
        }
    
    }
