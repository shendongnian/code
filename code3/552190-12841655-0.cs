    string commandText = "insert into company values(CompName, BusinessType, Pword) values(@CompName, @BusinessType, @Pword)";
    SqlCommand command = new SqlCommand(commandText, connection);
    command.Parameters.Add("@CompName", SqlDbType.VarChar);
    command.Parameters.Add("@BusinessType", SqlDbType.VarChar);
    command.Parameters.Add("@PWord", SqlDbType.VarChar);
