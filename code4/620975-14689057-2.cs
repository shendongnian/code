    var commandText = 
        @"insert into [server].[database2].[schema].[table] (col1, col2, ...)
        select col1, col2, ... from [server].[database1].[schema].[table]";
    
    using (var connection = new SqlConnection(connectionString))
    {
        using (var command = new SqlCommand(commandText, connection))
        {
            connection.Open();
            myCommand.ExecuteNonQuery();
        }
    }
