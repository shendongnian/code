    using BookSleeve;
    using System;
    using System.Runtime.Caching;
    using System.Text;
    using System.Threading;
    
    class MyCache : IDisposable
    {
        public void Dispose()
        {
            var tmp0 = conn;
            conn = null;
            if (tmp0 != null)
            {
                tmp0.Close(true);
                tmp0.Dispose();
            }
    
            var tmp1 = localCache;
            localCache = null;
            if (tmp1 != null)
                tmp1.Dispose();
    
            var tmp2 = sub;
            sub = null;
            if (tmp2 != null)
            {
                tmp2.Close(true);
                tmp2.Dispose();
            }
    
        }
        private RedisSubscriberConnection sub;
        private RedisConnection conn;
        private readonly int db;
        private MemoryCache localCache;
        private readonly string cacheInvalidationChannel;
        public MyCache(string configuration = "127.0.0.1:6379", int db = 0)
        {
            conn = ConnectionUtils.Connect(configuration);
            this.db = db;
            localCache = new MemoryCache("local:" + db.ToString());
            if (conn == null) throw new ArgumentException("It was not possible to connect to redis", "configuration");
            sub = conn.GetOpenSubscriberChannel();
            cacheInvalidationChannel = db.ToString() + ":inval"; // note that pub/sub is server-wide; use
                                                                 // a channel per DB here
            sub.Subscribe(cacheInvalidationChannel, Invalidate);   
        }
    
        private void Invalidate(string channel, byte[] payload)
        {
            string key = Encoding.UTF8.GetString(payload);
            var tmp = localCache;
            if (tmp != null) tmp.Remove(key);
        }
        private static readonly object nix = new object();
        public byte[] Get(string key)
        {
            // try local, noting the "nix" sentinel value
            object found = localCache[key];
            if (found != null)
            {
                return found == nix ? null : (byte[])found;
            }
            
            // fetch and store locally
            byte[] blob = conn.Wait(conn.Strings.Get(db, key));
            localCache[key] = blob ?? nix;
            return blob;
        }
       
        public void Set(string key, byte[] value, int timeoutSeconds = 60, bool broadcastInvalidation = true)
        {
            localCache[key] = value;
            conn.Strings.Set(db, key, value, timeoutSeconds);
            if (broadcastInvalidation)
                conn.Publish(cacheInvalidationChannel, key);
        }
    }
    
    static class Program
    {
        static void ShowResult(MyCache cache0, MyCache cache1, string key, string caption)
        {
            Console.WriteLine(caption);
            byte[] blob0 = cache0.Get(key), blob1 = cache1.Get(key);
            Console.WriteLine("{0} vs {1}",
                blob0 == null ? "(null)" : Encoding.UTF8.GetString(blob0),
                blob1 == null ? "(null)" : Encoding.UTF8.GetString(blob1)
                );
        }
        public static void Main()
        {
            MyCache cache0 = new MyCache(), cache1 = new MyCache();
            string someRandomKey = "key" + new Random().Next().ToString();
            ShowResult(cache0, cache1, someRandomKey, "Initially");
            cache0.Set(someRandomKey, Encoding.UTF8.GetBytes("hello"));
            Thread.Sleep(10); // the pub/sub is fast, but not *instant*
            ShowResult(cache0, cache1, someRandomKey, "Write to 0");
            cache1.Set(someRandomKey, Encoding.UTF8.GetBytes("world"));
            Thread.Sleep(10); // the pub/sub is fast, but not *instant*
            ShowResult(cache0, cache1, someRandomKey, "Write to 1");
        }
    }
