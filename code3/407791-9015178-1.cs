    using (var connection = new SqlConnection(myConnectionString))
    {
        connection.Open();
        var commnand  = connection.CreateCommand();
        command.CommandText = "CREATE DATABASE mydb";
        command.ExecuteNonQuery();
    }  
