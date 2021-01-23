	public interface ICache 
	{
	...
		object Get(string key, string regionName = null);
	...
	}
	
	public class MyCache : ICache
	{
		private readonly MemoryCache cache
		
		public MyCache(MemoryCache cache)
		{
			this.cache = cache.
		}
	...
        public object Get(string key, string regionName = null)
        {
            var regionKey = RegionKey(key, regionName);
            return cache.Get(regionKey);
        }	
		
		private string RegionKey(string key, string regionName)
		{
		   // NB Implements region as a suffix, for prefix, swap order in the format
           return string.IsNullOrEmpty(regionName) ? key : string.Format("{0}{1}{2}", key, "::", regionName);
		}
	...
	}
