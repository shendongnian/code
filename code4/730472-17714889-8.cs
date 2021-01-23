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
