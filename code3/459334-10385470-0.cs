    try
    {
                  
        SqlConnection connection = new SqlConnection(connectionString)
    }
    finally
    {
       connection.Dispose();
    }
