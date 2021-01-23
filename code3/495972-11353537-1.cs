    using (DbConnection myConn = dbFactory.CreateConnection())
    {
        myConn.ConnectionString = myConnectionStringSetting.ConnectionString;
        myConn.Open();
        myCommand.Connection = myConn;
        myCommand.ExecuteNonQuery();
        // Closed automatically due to being disposed
    }
