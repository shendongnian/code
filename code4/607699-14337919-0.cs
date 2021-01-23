    var conn = new SQLiteConnection(string.Format(Constants.SQLiteConnectionString, "db.db3"));
    conn.Open();
    using (SQLiteTransaction trans = conn.BeginTransaction()) {
        using (var cmd = conn.CreateCommand()) {
            cmd.CommandText = "INSERT INTO TableName (Id) VALUES (@Id)";
            cmd.Parameters.AddWithValue("@Id", someTextVariable);
            cmd.ExecuteNonQuery();
        }
    }
