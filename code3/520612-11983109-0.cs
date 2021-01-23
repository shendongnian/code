    Using (SqlConnection connection = new SqlConnection(connectionString))
    {
        try
        {
             connection.Open()
             // do something here
        }
        catch (SqlException ex)
        {
        }
        finally
        {
             connection.Close()
        } 
    }
