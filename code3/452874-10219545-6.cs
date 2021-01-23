    //code
    var connection = new SqlConnection("connection_string");
    var command = new SqlCommand();
    command.Connection = connection;
    command.CommandText = "usp_Search";
    command.CommandType = CommandType.StoredProcedure;
    if((string.IsNullOrEmpty(stringVariable1)) || (stringVariable2.ToLower().Equals("any"))) {
        command.Parameters.Add("@param1", SqlType.VarChar, 50).Value = DBNull.Value;
    } else {
        command.Parameters.Add("@param1", SqlType.VarChar, 50).Value = stringVariable1;
    }
    if((string.IsNullOrEmpty(stringVariable2)) || (stringVariable2.ToLower().Equals("any"))) {
        command.Parameters.Add("@param2", SqlType.VarChar, 50).Value = DBNull.Value;
    } else {
        command.Parameters.Add("@param2", SqlType.VarChar, 50).Value = stringVariable2;
    }
    // code
