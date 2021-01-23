    SqlConnection connection = null;
    try
    {
       connection = new SqlConnection();
       connection.Open
       // do some stuff with the connection
    }
    finally
    {
       if (connection != null)
       {
          connection.Dispose()
       }
    }
