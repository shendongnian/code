	List<Document> listFromCache = Cache[dataCacheName] as List<Document>;
	if (listFromCache != null)
	{
		Cache.Remove(dataCacheName);
		//listFromCache will NOT be null here.
		if (listFromCache != null)
		{
			Console.WriteLine("Not null!"); //this will run because it's not null
		}
	}
