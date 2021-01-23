    for (int remainingTries = Constants.MaxRetries; remainingTries >= 0; remainingTries--)
    {
        try
        {
            return DoWork();
        }
        catch (Exception ex)
        {
            // fall through to retry
        }
    }
    throw new WorkException(
            String.Format("Failed after {0} retries.", Constants.MaxRetries),
            ex);
