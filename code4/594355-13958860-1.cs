     public static Int32 Add<TMessage>(TMessage message)
         where TMessage: IMessageWithIMID
     {
        using (var connection = new MySqlConnection(connectionString))
        using (var command = new MySqlCommand("Add_Message", connection))
        {
            command.CommandType = CommandType.StoredProcedure;
            var properties = typeof(TObject).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var property in properties)
            {
                var parameterName = "@" + property.Name;
                var value = property.GetValue(message, null);
                command.Parameters.AddWithValue(parameterName, value);
            }
            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                // What's going on here? You are reading all rows but keep
                // overriding the value just read. Why not just fetch the
                // last row? Even only the single column IMID from the last
                // row would be sufficient. You could use ExecuteScalar().
                while (reader.Read())
                {
                    message.IMID = (Int32)reader["IMID"];
                }
            }
            return message.IMID;
        }
    }
