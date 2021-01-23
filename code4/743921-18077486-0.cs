    string[] files = { "1.8_DatabaseAndUsers.sql", "1.8_TablesAndTypes.sql", ... };
    foreach (var file in files)
    {
        // Simpler way of reading files (and doesn't leave the file handle open)
        string text = File.ReadAllText(file);
        // using statement to avoid leaking resources
        using (var conn = new SqlConnection(...))
        {
            var server = new Server(new ServerConnection(conn));
            server.ConnectionContext.ExecuteNonQuery(script);
        }
    }
