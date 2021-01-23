    using (var conn = new OracleConnection(connectionString)) {
        using (var command = new OracleCommand("INSERT INTO FOO (col) VALUES (?)")) {
            command.Connection = conn;
            command.Parameters.AddWithValue("?", value);
            command.ExecuteNonQuery();
        }
    }
