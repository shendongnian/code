    [Cached]
    public class MyTime : ContextBoundObject
    {
            [CachedMethod(1)]
            public DateTime Get()
            {
                    Console.WriteLine("Get invoked.");
                    return DateTime.Now;
            }
    
            public DateTime GetNoCache()
            {
                    Console.WriteLine("GetNoCache invoked.");
                    return DateTime.Now;
            }
    }
