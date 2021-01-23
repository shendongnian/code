    /// <summary>
    /// =================================================================================================================
    /// This is a static encapsulation of the Framework provided MemoryCache to make it easier to use.
    /// - Keys can be of any type, not just strings.
    /// - A typed Get method is provided for the common case where type of retrieved item actually is known.
    /// - Exists method is provided.
    /// - Except for the Set method with custom policy, some specific Set methods are also provided for convenience.
    /// - One SetAbsolute method with remove callback is provided as an example.
    ///   The Set method can also be used for custom remove/update monitoring.
    /// - Domain (or "region") functionality missing in default MemoryCache is provided.
    ///   This is very useful when adding items with identical keys but belonging to different domains.
    ///   Example: "Customer" with Id=1, and "Product" with Id=1
    /// - Clear method is provided to remove all items belonging to one domain.
    /// =================================================================================================================
    /// </summary>
    public static class MyCache
    {
        private const string KeySeparator = "_";
        private const string DefaultDomain = "DefaultDomain";
        private static MemoryCache Cache
        {
            get { return MemoryCache.Default; }
        }
        // -----------------------------------------------------------------------------------------------------------------------------
        // The default instance of the MemoryCache is used.
        // Memory usage can be configured in standard config file.
        // -----------------------------------------------------------------------------------------------------------------------------
        // cacheMemoryLimitMegabytes:   The amount of maximum memory size to be used. Specified in megabytes. 
        //                              The default is zero, which indicates that the MemoryCache instance manages its own memory
        //                              based on the amount of memory that is installed on the computer. 
        // physicalMemoryPercentage:    The percentage of physical memory that the cache can use. It is specified as an integer value from 1 to 100. 
        //                              The default is zero, which indicates that the MemoryCache instance manages its own memory 
        //                              based on the amount of memory that is installed on the computer. 
        // pollingInterval:             The time interval after which the cache implementation compares the current memory load with the 
        //                              absolute and percentage-based memory limits that are set for the cache instance.
        //                              The default is two minutes.
        // -----------------------------------------------------------------------------------------------------------------------------
        //  <configuration>
        //    <system.runtime.caching>
        //      <memoryCache>
        //        <namedCaches>
        //          <add name="default" cacheMemoryLimitMegabytes="0" physicalMemoryPercentage="0" pollingInterval="00:02:00" />
        //        </namedCaches>
        //      </memoryCache>
        //    </system.runtime.caching>
        //  </configuration>
        // -----------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Store an object and let it stay in cache until manually removed.
        /// </summary>
        public static void SetPermanent(string key, object data, string domain = null)
        {
            CacheItemPolicy policy = new CacheItemPolicy { };
            Set(key, data, policy, domain);
        }
        /// <summary>
        /// Store an object and let it stay in cache x minutes from write.
        /// </summary>
        public static void SetAbsolute(string key, object data, double minutes, string domain = null)
        {
            CacheItemPolicy policy = new CacheItemPolicy { AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(minutes) };
            Set(key, data, policy, domain);
        }
        /// <summary>
        /// Store an object and let it stay in cache x minutes from write.
        /// callback is a method to be triggered when item is removed
        /// </summary>
        public static void SetAbsolute(string key, object data, double minutes, CacheEntryRemovedCallback callback, string domain = null)
        {
            CacheItemPolicy policy = new CacheItemPolicy { AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(minutes), RemovedCallback = callback };
            Set(key, data, policy, domain);
        }
        /// <summary>
        /// Store an object and let it stay in cache x minutes from last write or read.
        /// </summary>
        public static void SetSliding(object key, object data, double minutes, string domain = null)
        {
            CacheItemPolicy policy = new CacheItemPolicy { SlidingExpiration = TimeSpan.FromMinutes(minutes) };
            Set(key, data, policy, domain);
        }
        /// <summary>
        /// Store an item and let it stay in cache according to specified policy.
        /// </summary>
        /// <param name="key">Key within specified domain</param>
        /// <param name="data">Object to store</param>
        /// <param name="policy">CacheItemPolicy</param>
        /// <param name="domain">NULL will fallback to default domain</param>
        public static void Set(object key, object data, CacheItemPolicy policy, string domain = null)
        {
            Cache.Add(CombinedKey(key, domain), data, policy);
        }
        /// <summary>
        /// Get typed item from cache.
        /// </summary>
        /// <param name="key">Key within specified domain</param>
        /// <param name="domain">NULL will fallback to default domain</param>
        public static T Get<T>(object key, string domain = null)
        {
            return (T)Get(key, domain);
        }
        /// <summary>
        /// Get item from cache.
        /// </summary>
        /// <param name="key">Key within specified domain</param>
        /// <param name="domain">NULL will fallback to default domain</param>
        public static object Get(object key, string domain = null)
        {
            return Cache.Get(CombinedKey(key, domain));
        }
        /// <summary>
        /// Check if item exists in cache.
        /// </summary>
        /// <param name="key">Key within specified domain</param>
        /// <param name="domain">NULL will fallback to default domain</param>
        public static bool Exists(object key, string domain = null)
        {
            return Cache[CombinedKey(key, domain)] != null;
        }
        /// <summary>
        /// Remove item from cache.
        /// </summary>
        /// <param name="key">Key within specified domain</param>
        /// <param name="domain">NULL will fallback to default domain</param>
        public static void Remove(object key, string domain = null)
        {
            Cache.Remove(CombinedKey(key, domain));
        }
        /// <summary>
        /// Remove all items belonging to specified domain.
        /// </summary>
        /// <param name="domain">NULL will fallback to default domain</param>
        public static void Clear(string domain = null)
        {
            if (string.IsNullOrEmpty(domain))
                domain = DefaultDomain;
            var keys = Cache.Select(item => item.Key);
            foreach (var combinedKey in keys)
            {
                if (ParseDomain(combinedKey) == domain)
                    Cache.Remove(combinedKey);
            }
        }
        #region Support Methods
        /// <summary>
        /// Parse domain from combinedKey.
        /// This method is exposed publicly because it can be useful in callback methods.
        /// The key property of the callback argument will in our case be the combinedKey.
        /// To be interpreted, it needs to be split into domain and key with these parse methods.
        /// </summary>
        public static string ParseDomain(string combinedKey)
        {
            return combinedKey.Substring(0, combinedKey.IndexOf(KeySeparator));
        }
        /// <summary>
        /// Parse key from combinedKey.
        /// This method is exposed publicly because it can be useful in callback methods.
        /// The key property of the callback argument will in our case be the combinedKey.
        /// To be interpreted, it needs to be split into domain and key with these parse methods.
        /// </summary>
        public static string ParseKey(string combinedKey)
        {
            return combinedKey.Substring(combinedKey.IndexOf(KeySeparator) + KeySeparator.Length);
        }
        /// <summary>
        /// Create a combined key from given values.
        /// The combined key is used when storing and retrieving from the inner MemoryCache instance.
        /// Example: Product_76
        /// </summary>
        /// <param name="key">Key within specified domain</param>
        /// <param name="domain">NULL will fallback to default domain</param>
        private static string CombinedKey(object key, string domain)
        {
            return string.Format("{0}{1}{2}", string.IsNullOrEmpty(domain) ? DefaultDomain : domain, KeySeparator, key);
        }
        #endregion
    }
