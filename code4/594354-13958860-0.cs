     public static Int32 Add<TMessage>(TMessage message)
         where TMessage: IMessageWithIMID
     {
        using (var connection = new MySqlConnection(MySqlConnection))
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
                // the last value? You could use ExecuteScalar().
                while (reader.Read())
                {
                    message.IMID = (Int32)reader["IMID"];
                }
            }
            return message.IMID;
        }
    }
    internal interface IMessageWithIMID
    {
        Int32 IMID { get; set; }
    }
