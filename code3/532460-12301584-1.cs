    public void PreventExceptionsFor(Action actionToRun())
    {
        try
        {
             actionToRun();
        }
        catch
        {}
    }
