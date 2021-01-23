    using (var conn = new SqlConnection(ConnectionString))
    using (var cmd = conn.CreateCommand())
    {
        conn.Open();
        cmd.CommandText = "SELECT foo FROM bar";
        using (var reader = cmd.ExecuteCommand())
        {
            while (reader.Read())
            {
                // TODO: consume your resultset
            }
        }
    }
