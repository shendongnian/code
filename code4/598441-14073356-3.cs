    new Thread(() => Console.WriteLine("1-" + GetCachedValue("1").Value)).Start();
    new Thread(() => Console.WriteLine("2-" + GetCachedValue("1").Value)).Start();
----
    Lazy<object> GetCachedValue(string id)
    {
        lock (Cache)
        {
            if (!Cache.ContainsKey(id))
            {
                Lazy<object> lazy = new Lazy<object>(() =>
                    {
                        Console.WriteLine("**Long Running Job**");
                        Thread.Sleep(3000);
                        return int.Parse(id);
                    }, 
                    true);
                Cache.Add(id, lazy);
                Console.WriteLine("added to cache");
            }
            return Cache[id];
        }
    }
