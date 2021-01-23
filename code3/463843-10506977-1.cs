    SqlDataReader dr;
    try
    {   
        dr = GetMoreData();
        // do your stuff
    }
    catch(Exception ex)
    {
       // handle the exception
    }
    finally
    {
       // close the reader
       dr.Dispose();
    }
