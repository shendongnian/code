    void ThrowLoggedException<T>()
    {
        try
        {
            throw new T("You did something bad");
        }
        catch (Exception ex)
        {
            // Log event here.
            throw;
        }
    }
