    try
    {
    connection = new Connection();
    connection.Open(); // open the connection
    //work with the connection, DB CRUD operations
    }
    finally
    {
    if(connection != null)
         connection.Close(); // close the connection in finally block
                             // so that even if the exception occurs, connection gets closed. 
    }
