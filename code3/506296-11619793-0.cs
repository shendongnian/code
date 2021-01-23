    protected void TryNTimes(int numberOfTries, Action action)
    {
        try
        {
            if (numberOfTries == 0) return;
            action();
        }
        catch (Exception)
        {
            TryNTimes(numberOfTries - 1, action);
        }
    }
