    public static T Retry(Task<T> original, int retryCount)
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
    }
