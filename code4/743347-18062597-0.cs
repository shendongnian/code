    // SqlConnection connection = cmd.Connection;
    connection.Open();
    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
    {
        int aIndex = reader.GetOrdinal("A");
        int bIndex = reader.GetOrdinal("B");
        int cIndex = reader.GetOrdinal("C");
        while (reader.Read())  // one loop iteration per record returned from SELECT
        {
            string a = cmd.GetString(aIndex);
            int b = cmd.GetInt32(bIndex);
            bool a = cmd.GetBoolean(cIndex);
            … // do something with a, b, and c
        }        
    }
