    public void TryCatch<ExceptionT>(Action tryMethod, Action<ExceptionT> catchMethod)
        where ExceptionT : Exception
    {
        // ToDo: ArgumentChecking!
        try
        {
            tryMethod();
        }
        catch(ExceptionT ex)
        {
            catchMethod(ex);
        }
    }
