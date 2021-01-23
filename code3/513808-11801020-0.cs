    public T TryOrDefault<T>(Func<T> act, int errorCode, Func<BazException, T> onError)
    {
        try
        {
            return act;
        }
        catch(BazException ex)
        {
            WriteLogMessage(ex, errorCode);
            return onError(ex);
        }
    }
