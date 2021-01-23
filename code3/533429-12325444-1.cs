    public class ObjectLimitMemoryCache : MemoryCache
    {
	private const int ObjectLimit = 2000;
	private const string IndexKey = "ObjectLimitIndexKey";
	
	public ObjectLimitMemoryCache(string name, NameValueCollection config) 
	: base (name, config)
	{
	}
	
	new public static ObjectLimitMemoryCache Default { get { return new ObjectLimitMemoryCache(Guid.NewGuid().ToString(), new NameValueCollection());}}
	
	public override bool Add(string key, Object value, DateTimeOffset absoluteExpiration, string region = null)
	{
		try
		{
			var indexedKeys = (List<string>)(base.Get(IndexKey) ?? new List<string>());
			if (base.Add(key, value, absoluteExpiration))
			{
				string existingKey;
				if (string.IsNullOrEmpty(existingKey = indexedKeys.FirstOrDefault(x=>x == key)))
				{
					indexedKeys.Add(key);
				}
				if (base.GetCount() > ObjectLimit)
				{
					base.Remove(indexedKeys.First());
					indexedKeys.RemoveAt(0);
				}
				base.Add(IndexKey, indexedKeys, new DateTimeOffset(DateTime.Now.AddHours(2))); 
				return true;
			}
			return false;
		}
		catch
		{
    //Log something and other fancy stuff
			throw;
		}
	}
    }
