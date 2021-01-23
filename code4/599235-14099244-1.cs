    public static IEnumerable<int> GetIds(string name)
    {
        using (var conn = new SqlConnection("Your connection string comes here"))
        using (var cmd = conn.CreateCommand())
        {
            conn.Open();
            cmd.CommandText = "select ID from Customer where Name=@Name";
            cmd.Parameters.AddWithValue("@Name", name);
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    yield return reader.GetInt32(reader.GetOrdinal("ID"));
                }
            }
        }
    }
