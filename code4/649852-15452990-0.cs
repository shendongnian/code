    string connectionString = ....
    using (var conn = new SqlConnection(connectionString))
    using (var cmd = conn.CreateCommand())
    {
        conn.Open();
        cmd.CommandText = "SELECT TOP 10 FROM drug WHERE name LIKE @name";
        cmd.Parameters.AddWithValue("@name", Dname + '%');
        using (var reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                ...
            }
        }
    }
