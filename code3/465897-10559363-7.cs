    public class ConcurrentCache : IDisposable
    {
      private readonly ConcurrentDictionary<string, Tuple<DateTime?, Lazy<object>>> _cache = 
        new ConcurrentDictionary<string, Tuple<DateTime?, Lazy<object>>>();
      private readonly Thread ExpireThread = new Thread(ExpireMonitor);
      public ConcurrentCache(){
        ExpireThread.Start();
      }
      public void Dispose()
      {
        //yeah, nasty, but this is a 'naive' implementation :)
        ExpireThread.Abort();
      }
      public void ExpireMonitor()
      {
        while(true)
        {
          Thread.Sleep(1000);
          DateTime expireTime = DateTime.Now;
          var toExpire = _cache.Where(kvp => kvp.First != null &&
            kvp.Item1.Value < expireTime).Select(kvp => kvp.Key).ToArray();
          Tuple<string, Lazy<object>> removed;
          object removedLock;
          foreach(var key in toExpire)
          {
            _cache.TryRemove(key, out removed);
          }
        }
      }
      public object CacheOrAdd(string key, Func<string, object> factory, 
        TimeSpan? expiry)
      {
        return _cache.GetOrAdd(key, (k) => { 
          //get or create a new object instance to use 
          //as the lock for the user code
            //here 'k' is actually the same as 'key' 
            return Tuple.Create(
              expiry.HasValue ? DateTime.Now + expiry.Value : (DateTime?)null,
              new Lazy<object>(() => factory(k)));
        }).Item2.Value; 
      }
    }
