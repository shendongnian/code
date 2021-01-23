    var commandText = 
        @"insert into [server].[database2].[schema].[table] (col1, col2, ...)
        select col1, col2, ... from [server].[database1].[schema].[table]";
    
    using (SqlConnection myConn = new SqlConnection(ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand(commandText, myConn))
        {
            myConn.Open();
            myCommand.ExecuteNonQuery();
        }
    }
