    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    
    string validationQuery = "SELECT * FROM Users WHERE FName = @name";
    SqlCommand validationCommand = new SqlCommand(validationQuery, connection);
    validationCommand.Parameters.Add("@name", SqlDbType.VarChar).Value = loginUserSelected;
    
    connection.Open();
    
    SqlDataReader validationReader = validationCommand.ExecuteReader(CommandBehavior.CloseConnection);
    
    if (!validationReader.Read())
    {
        string insertQuery = "INSERT INTO Users (FName) VALUES (@name)";
        SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
        insertCommand.Parameters.Add("@name", SqlDbType.VarChar).Value = loginUserSelected;
    
        connection.Open();
    
        insertCommand.ExecuteNonQuery();
    
        insertCommand.Dispose();
    
        connection.Close();
    }
    else
    {
        //Uh oh, username already taken
    }
    
    validationReader.Close();
    
    validationCommand.Dispose();
