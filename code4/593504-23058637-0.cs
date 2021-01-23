    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.IO;
    using System.Runtime.Caching;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Threading.Tasks;
    
    
    namespace ReadOnlyCache
    {
    	class Program
    	{
    
    		static void Main()
    		{
    			Start();
    			Console.ReadLine();
    		}
    
    		private static async void Start() {
    			while (true)
    			{
    				TestMemoryCache();
    				await Task.Delay(TimeSpan.FromSeconds(1));
    			}
    		}
    
    		private static void TestMemoryCache() {
    			List<Item> items = null;
    			string cacheIdentifier = "items";
    
    			var cache = ReadonlyMemoryCache.Default;
    
    			//change to MemoryCache to understand the problem
    			//var cache = MemoryCache.Default;
    
    			if (cache.Contains(cacheIdentifier))
    			{
    				items = cache.Get(cacheIdentifier) as List<Item>;
    				Console.WriteLine("Got {0} items from cache: {1}", items.Count, string.Join(", ", items));
    
    				//modify after getting from cache, cached items will remain unchanged
    				items[0].Value = DateTime.Now.Millisecond.ToString();
    
    			}
    			if (items == null)
    			{
    				items = new List<Item>() { new Item() { Value = "Steve" }, new Item() { Value = "Lisa" }, new Item() { Value = "Bob" } };
    				Console.WriteLine("Reading {0} items from disk and caching", items.Count);
    
    				//cache for x seconds
    				var policy = new CacheItemPolicy() { AbsoluteExpiration = new DateTimeOffset(DateTime.Now.AddSeconds(5)) };
    				cache.Add(cacheIdentifier, items, policy);
    
    				//modify after writing to cache, cached items will remain unchanged
    				items[1].Value = DateTime.Now.Millisecond.ToString();
    			}
    		}
    	}
    
    	//cached items must be serializable
    
    	[Serializable]
    	class Item {
    		public string Value { get; set; }
    		public override string ToString() { return Value; }
    	}
    	
    	/// <summary>
    	/// Readonly version of MemoryCache. Objects will always be returned in-value, via a deep copy.
    	/// Objects requrements: [Serializable] and sometimes have a deserialization constructor (see http://stackoverflow.com/a/5017346/2440) 
    	/// </summary>
    	public class ReadonlyMemoryCache : MemoryCache
    	{
    
    		public ReadonlyMemoryCache(string name, NameValueCollection config = null) : base(name, config) {
    		}
    
    		private static ReadonlyMemoryCache def = new ReadonlyMemoryCache("readonlydefault");
    
    		public new static ReadonlyMemoryCache Default {
    			get
    			{
    				if (def == null)
    					def = new ReadonlyMemoryCache("readonlydefault");
    				return def;
    			}
    		}
    
    		//we must run deepcopy when adding, otherwise items can be changed after the add() but before the get()
    
    		public new bool Add(CacheItem item, CacheItemPolicy policy)
    		{
    			return base.Add(item.DeepCopy(), policy);
    		}
    
    		public new object AddOrGetExisting(string key, object value, DateTimeOffset absoluteExpiration, string regionName = null)
    		{
    			return base.AddOrGetExisting(key, value.DeepCopy(), absoluteExpiration, regionName);
    		}
    
    		public new CacheItem AddOrGetExisting(CacheItem item, CacheItemPolicy policy)
    		{
    			return base.AddOrGetExisting(item.DeepCopy(), policy);
    		}
    
    		public new object AddOrGetExisting(string key, object value, CacheItemPolicy policy, string regionName = null)
    		{
    			return base.AddOrGetExisting(key, value.DeepCopy(), policy, regionName);
    		}
    
    		//methods from ObjectCache
    
    		public new bool Add(string key, object value, DateTimeOffset absoluteExpiration, string regionName = null)
    		{
    			return base.Add(key, value.DeepCopy(), absoluteExpiration, regionName);
    		}
    
    		public new bool Add(string key, object value, CacheItemPolicy policy, string regionName = null)
    		{
    			return base.Add(key, value.DeepCopy(), policy, regionName);
    		}
    
    		//for unknown reasons, we also need deepcopy when GETTING values, even though we run deepcopy on all (??) set methods.
    
    		public new object Get(string key, string regionName = null)
    		{
    			var item = base.Get(key, regionName);
    			return item.DeepCopy();
    		}
    
    		public new CacheItem GetCacheItem(string key, string regionName = null)
    		{
    			var item = base.GetCacheItem(key, regionName);
    			return item.DeepCopy();
    		}
    
    	}
    
    
    	public static class DeepCopyExtentionMethods
    	{
    		/// <summary>
    		/// Creates a deep copy of an object. Must be [Serializable] and sometimes have a deserialization constructor (see http://stackoverflow.com/a/5017346/2440) 
    		/// </summary>
    		public static T DeepCopy<T>(this T obj)
    		{
    			using (var ms = new MemoryStream())
    			{
    				var formatter = new BinaryFormatter();
    				formatter.Serialize(ms, obj);
    				ms.Position = 0;
    
    				return (T)formatter.Deserialize(ms);
    			}
    		}
    	}
    
    
    
    }
