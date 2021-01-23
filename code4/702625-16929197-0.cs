    try
    {
        // Open connection
        proxy.Open();
        // Do your work with the open connection here...
    }
    finally
    {
        try
        {
            proxy.Close();
        }
        catch
        {
            // Close failed
            proxy.Abort();
        }
    }
