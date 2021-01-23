    using System.Web;
    using System.Web.Caching;
    class Program
    {
        static void Main(string[] args)
        {
            Cache cache = HttpRuntime.Cache;
            string object1 = "Object1";
            string object2 = "Object2";
            cache.Add(
                "Key", object1, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, 10, 0), CacheItemPriority.Normal, null);
            cache.Add("Key", object2, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, 10, 0), CacheItemPriority.Normal, null);
            string cachedstring = (string)cache.Get("Key");
            Console.WriteLine(cachedstring);
            Console.ReadLine();
        }
    }
