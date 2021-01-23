    public interface IRepositoryCollection
    {
        DateTime dateCreated { get; set; }
    }
    public class Cache<T> : Dictionary<string, T>
    {
        private int cacheDuration = 1;
        private int maxCacheSize = 20;
        public Cache(int cacheDuration, int maxCacheSize)
        {
            this.cacheDuration = cacheDuration;
            this.maxCacheSize = maxCacheSize;
        }
        public new void Add(string key, T invoices)
        {
            base.Add(key, invoices);
            RemoveOld();
            RemoveOldest();
        }
        public void RemoveOld()
        {
            foreach (KeyValuePair<string, T> cacheItem in this)
            {
                Interfaces.IRepositoryCollection currentvalue = (Interfaces.IRepositoryCollection)cacheItem.Value;
                if (currentvalue.dateCreated < DateTime.Now.AddHours(-cacheDuration))
                {
                    this.Remove(cacheItem.Key);
                }
            }
        }
        public void RemoveOldest()
        {
            do
            {
                this.Remove(this.First().Key);
            }
            while (this.Count > maxCacheSize);
        }
    }
