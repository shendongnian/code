        using (var connection = new OracleConnection(connectionString))
        {
            connection.Open();
            using (var command = new OracleCommand(queryString, connection))
            {
               // add parameters here 
               command.ExecuteNonQuery();
            }
    
         }
