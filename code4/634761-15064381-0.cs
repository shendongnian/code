    private void ThrowingMethod()
    {
        try
        {
            throw new InvalidOperationException("some exception");
        }
        catch
        {
            throw;
        }
        finally
        {
            
        }
    }
