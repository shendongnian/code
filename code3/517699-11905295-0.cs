    var connection = new SqlConnection("connectionstring");
    var command = connection.CreateCommand();
    command.CommandText = "insert...."; // sql command with named parameters
    // set the named parameter values
    command.Parameters["@Value1"] = "Mark wa...";
    // execute 
    command.ExecuteNonQuery();
     
