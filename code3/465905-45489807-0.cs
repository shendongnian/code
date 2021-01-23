     public static class MemoryCacheExtensions
     {
         public static T LazyAddOrGetExitingItem<T>(this MemoryCache memoryCache, string key, Func<T> getItemFunc, DateTimeOffset absoluteExpiration)
         {
             var item = new Lazy<T>(
                 () => getItemFunc(),
                 LazyThreadSafetyMode.PublicationOnly // Do not cache lazy exceptions
             );
     
             var cachedValue = memoryCache.AddOrGetExisting(key, item, absoluteExpiration) as Lazy<T>;
     
             return (cachedValue != null) ? cachedValue.Value : item.Value;
         }
     }
