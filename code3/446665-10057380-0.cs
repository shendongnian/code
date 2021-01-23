    try
    {
        SqlConnection awesomeConn = new SqlConnection(connection);
        // do some stuff
    }
    finally 
    {
        awesomeConn.Dispose();
    }
