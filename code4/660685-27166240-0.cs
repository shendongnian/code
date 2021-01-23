    public static void AnyFuncExecutor(Action a)
    {
        try
        {
            a();
        }
        catch (Exception exception)
        {
            throw;
        }
    }
