    public bool DoWorkWithRetry()
    {
        Exception e;
        for (int remainingTries = Constants.MaxRetries; remainingTries >= 0; remainingTries--)
        {
            try
            {
                return DoWork();
            }
            catch (Exception ex)
            {
                e = ex;
            }
        }
        throw new WorkException(
             String.Format("Failed after {0} retries.", Constants.MaxRetries), e);
    }
