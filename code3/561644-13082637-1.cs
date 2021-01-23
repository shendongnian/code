    var stream = new MemoryStream();
    try
    {
        try
        {
            // Do something with the memory stream
        }
        catch(Exception ex)
        {
            // Do something to handle the exception
        }
    }
    finally
    {
        if (stream != null)
        {
            stream.Dispose();
        }
    }
