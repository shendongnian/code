    //code
    var connection = new SqlConnection("connection_string");
    var command = new SqlCommand();
    command.Connection = connection;
    command.CommandText = "usp_Search";
    command.CommandType = CommandType.StoredProcedure;
    command.Parameters.Add("@param1", SqlType.VarChar, 50).Value = stringVariable1;
    command.Parameters.Add("@param2", SqlType.VarChar, 50).Value = stringVariable2;
    // code
