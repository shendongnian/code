      DateTime updatedtime = obj["updated_time"] as DateTime;
      var statement = "..... where Updated_time > :updatedtime";
        using (OracleConnection connection = new OracleConnection(connectionString))
        using (OracleCommand command = new OracleCommand(statement, connection))
        {
            command.Parameters.AddWithValue(":updatedtime", updatedtime );
            command.Connection.Open();
            command.ExecuteNonQuery();
        }
