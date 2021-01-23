    try
    {
        factory.Close(TimeSpan.FromSeconds(0.25))
    }
    catch
    {
        if (factory != null)
        {
            factory.Abort();
        }
        throw;
    }
