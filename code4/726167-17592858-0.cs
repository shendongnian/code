    using (SQLiteConnection c = new SQLiteConnection(ConnectionString))
    {
        c.Open();
        using (SQLiteCommand cmd = new SQLiteCommand(sql, c))
        {
            cmd.ExecuteNonQuery();
        }
    }
