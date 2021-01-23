    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
    public sealed class TestServerConfig : ConfigBase, ITestInterface
    {
        private ConcurrentDictionary<string, DateTime> dates = new ConcurrentDictionary<string, DateTime>();
    
        public DateTime GetDate(string key)
        {
            DateTime result;
               
            if (this.dates.TryGetValue(key, out result))
            {
                return result;
            }
            else
            {
                return DateTime.MinValue;
            }
        }
        public void SetDate(string key, DateTime expirationDate)
        {
            this.dates.AddOrUpdate(key, expirationDate, (usedKey, oldValue) => expirationDate);
        }
    }
