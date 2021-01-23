    try
    {
        // your code to run
    }
    catch(SqlException ex)
    {
        Console.WriteLine(ex.Message);
    } 
    // Catch all Exceptions
    catch(Exception)
    {
        Console.WriteLine(Message);
    }
