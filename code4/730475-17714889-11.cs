    void Execute(Action action)
    {
        try
        {
            action();
        }
        catch (Exception e)
        {
            Logger.Log(e);
            throw;
        }
    }
    T Execute<T>(Func<T> func)
    {
        try
        {
            return func();
        }
        catch (Exception e)
        {
            Logger.Log(e);
            throw;
        }
    }
