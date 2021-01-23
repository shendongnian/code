    public IEnumerable<string> GetTagList()
    {
        using (var connection = new SqlConnection(Properties.Settings.Default.DBConnectionString))
        using (var cmd = connection.CreateCommand())
        {
            connection.Open();
            cmd.CommandText = "select Tag from TagsTable"; // update select command accordingly
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    yield return reader.GetString(reader.GetOrdinal("Tag"));
                }
            }
        }
    }
