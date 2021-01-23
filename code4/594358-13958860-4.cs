     public static Int32 Add<TMessage>(TMessage message)
         where TMessage: IMessageWithIMID
     {
        using (var connection = new MySqlConnection(connectionString))
        using (var command = new MySqlCommand("Add_Message", connection))
        {
            command.CommandType = CommandType.StoredProcedure;
            // We look only at public instance properties but you can easily
            // change this and even use a custom attribute to control which
            // properties to include.
            var properties = typeof(TObject).GetProperties(BindingFlags.Public |
                                                           BindingFlags.Instance);
            foreach (var property in properties)
            {
                var parameterName = "@" + property.Name;
                var value = property.GetValue(message, null);
                command.Parameters.AddWithValue(parameterName, value);
            }
            connection.Open();
            message.IMID = (Int32)command.ExecuteScalar();
            return message.IMID;
        }
    }
