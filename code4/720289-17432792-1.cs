    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
    public sealed class TestServerConfig : ConfigBase, ITestInterface
    {
        private ReaderWriterLockSlim updateLock = new ReaderWriterLockSlim();
    
        private SortedList<string, DateTime> dates = new SortedList<string, DateTime>();
        
    
        public DateTime GetDate(string key)
        {
            try
            {   
                this.updateLock.EnterReadLock();
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
                this.updateLock.ExitReadLock();
            }
        }
        public void SetDate(string key, DateTime expirationDate)
        {
            try
            {
                this.updateLock.EnterWriteLock();
    
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
                 this.updateLock.ExitWriteLock();
            }
        }
    }
