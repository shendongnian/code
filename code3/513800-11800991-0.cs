    T TryExecute<T>(Func<T> action)
    {
        T result = default(T);
        try
        {
            result = action();
        }
        catch (Exception ex)
        {
            // shared exception handling code here ...
        }
        return result;
    }
