    public DateTime GetDate(string key)
    {
        cacheLock.EnterReadLock();
        try
        {
            if (this.dates.ContainsKey(key))
            {
                return this.dates[key];
            }
            else
            {
                return DateTime.MinValue;
            }
        }
        finally
        {
            cacheLock.ExitReadLock();
        }
    }
    public void SetDate(string key, DateTime expirationDate)
    {
        cacheLock.EnterWriteLock();
        try
        {
            if (this.dates.ContainsKey(key))
            {
                this.dates[key] = expirationDate;
            }
            else
            {
                this.dates.Add(key, expirationDate);
            }
        }
        finally
        {
            cacheLock.ExitWriteLock();
        }
    }
