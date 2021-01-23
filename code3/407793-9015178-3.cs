    using (var connection = new SqlConnection(myConnectionString))
    {
        connection.Open();
        var command = connection.CreateCommand();
        command.CommandText = "CREATE DATABASE mydb";
        command.ExecuteNonQuery();
    }  
