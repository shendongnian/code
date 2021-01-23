    public List<string> GetFields()
    {
        List<string> fields = new List<string>();
        string CommandText = "SELECT Field1, Field2 FROM TableName";
        using (var connection = new SqlConnection(epaCUBE_DB.GetConnectionString()))
        {
            connection.Open();
            using (var cmd = new SqlCommand(CommandText, connection))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    fields.Add(reader["Field1"].ToString() + ": " + reader["Field2"].ToString());
                }
            }
        }
        return fields;
    }
