    static IEnumerable<MyModel> SelectTop100Models() 
    {
        var connectionString = ConfigurationManager.ConnectionStrings["XXX"].ConnectionString;
        using (var conn = new SqlConnection(connectionString))
        using (var cmd = conn.CreateCommand())
        {
            conn.Open();
            cmd.CommandText = "SELECT top 100 * FROM x";
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    // EXECUTION WILL CONTINUE FROM HERE AND NOT AT THE BEGINNING
                    // OF THE METHOD
                    yield return new MyModel
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("ID")),
                        Name = reader.GetString(reader.GetOrdinal("Name")),
                    };
                }
            }
        }
    }
