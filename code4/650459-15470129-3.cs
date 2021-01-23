    public static Func<T> Retry(Func<T> original, int retryCount)
    {
        return () =>
        {
            while (true)
            {
                try
                {
                    return original();
                }
                catch (Exception e)
                {
                    if (retryCount == 0 || !ShouldRetry(e))
                    {
                        throw;
                    }
                    
                    // TODO: Logging
                    retryCount--;
                }
            }
       };
    }
    public static bool ShouldRetry(Exception e) {
        return (e is MySpecialExceptionThatAllowsForARetry)
    }
