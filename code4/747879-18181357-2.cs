    using System.Web;
    public static class CacheHelper
    {
        public static void SaveTocache(string cacheKey, object savedItem, DateTime absoluteExpiration)
        {
            if (IsIncache(cacheKey))
            {
                HttpContext.Current.Cache.Remove(cacheKey);
            }
            HttpContext.Current.Cache.Add(cacheKey, savedItem, null, System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(0, 10, 0), System.Web.Caching.CacheItemPriority.Default, null);
        }
        public static T GetFromCache<T>(string cacheKey) where T : class
        {
            return HttpContext.Current.Cache[cacheKey] as T;
        }
        public static void RemoveFromCache(string cacheKey)
        {
            HttpContext.Current.Cache.Remove(cacheKey);
        }
        public static bool IsIncache(string cacheKey)
        {
            return HttpContext.Current.Cache[cacheKey] != null;
        }
    }
