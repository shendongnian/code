    try
    {
    }
    catch (Exception ex)
    {
        if (ex is CustomExceptionA)
        {
            throw;
        }
        else
        {
            // handle
        }
    }
