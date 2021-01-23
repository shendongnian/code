    public void DoAction(Action action)
    {
        try
        {
            action();
        }
        catch
        {
            // Handle exception as you wish...
        }
    }
