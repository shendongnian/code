    var command = new SqlCommand(commandText, sqlConnection);
    command.CommandType = CommandType.StoredProcedure;
    using(var reader = command.ExecuteReader())
    {
    while(reader.Read())
    {
    var result = reader[0];
    //Respond to result.
    }
    }
