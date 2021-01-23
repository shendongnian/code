    public class TestClass : IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("disposed");
        }
    }
    MemoryCache _MemoryCache = new MemoryCache("TEST");
    void Test()
    {
        _MemoryCache.Add("key",
                          new TestClass(),
                          new CacheItemPolicy()
                          {
                              AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(10),
                              RemovedCallback = () => { Console.WriteLine("removed"); }
                          });
    }
