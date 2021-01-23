    public bool DoWorkWithRetry()
    {
        for (int remainingTries = Constants.MaxRetries;; remainingTries--)
        {
            // etc...
        }
    }
