    using System;
    using Microsoft.ApplicationServer.Caching;
    namespace WebRole1.Classes
    {
        public class AzureCache
        {
            public static DataCache cache { get; set; }
            public static DataCacheFactory dataCacheFactory { get; set; }
        public AzureCache()
        {
			if (cache == null){
                DataCacheFactoryConfiguration cfg = new DataCacheFactoryConfiguration();
                cfg.AutoDiscoverProperty = new DataCacheAutoDiscoverProperty(true, "CacheWorkerRole1"); 
                dataCacheFactory = new DataCacheFactory(cfg);
                cache = dataCacheFactory.GetDefaultCache();
			}
        }
        public void Add(string item, object value)
        {                                                                              
           cache.Add(item, value);
        }
        public void Add(string item, object value, TimeSpan timeout)
        {
           cache.Put(item, value, timeout);
        }
        public object Get(string item)
        {   
            return cache.Get(item);
        }
        
        public TimeSpan TimeRemaining (string item)
        {
            DataCacheItem DCitem = cache.GetCacheItem(item);
            return DCitem.Timeout;
        }
        public void Flush()
        {
            cache.Clear();
            DataCacheFactory cacheFactory = new DataCacheFactory();
            cache = cacheFactory.GetDefaultCache();
            
        }
        
        }
    }
