    SqlDataReader reader;
    try
    {
       reader = methodThatReturnsAReader();
    }
    catch(Exception ex)
    {
       // handle the exception
    }
    finally
    {
       // close the reader
       reader.Dispose();
    }
      
