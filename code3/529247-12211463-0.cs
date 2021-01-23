    public void LogIfSomeException(Action action, string message)
    {
        try
        {
            action();
        }
        catch (SomeException e)
        {
            log.Error(message);
            FunctionA();
        }
    }
