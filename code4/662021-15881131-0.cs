	// todo: probably some thread safety
	public class AccessFilterFactory
	{
		private static AccessFilterFactory _instance = new AccessFilterFactory();;
		private AccessFilterFactory()
		{
		}
		
		public AccessFilterFactory Instance
		{
			get
			{
				return _instance;
			}
		}
		private Cache<int, Filter> someKindaCache = new Cache<int, Filter> ();
		// gets a cached filter if already built, if not it creates one
		// caches it and returns it
		public Filter GetFilterForUser(int userId)
		{
			// return from cache if you got it
			if(someKindaCache.Exists(userId))
				return someKindaCache.Get(userId);
			// if not, build and cache it
			BooleanQuery filterQuery = new BooleanQuery();
			foreach(string id in ids)
			{
				filterQuery.Add(new TermQuery(new Term("EmId", id)),  BooleanClause.Occur.SHOULD);
			}
			Filter cachingFilter = new CachingWrapperFilter(new QueryWrapperFilter(filterQuery));
			someKindaCache.Put(userId, cachingFilter);
			return cachingFilter;
		}
		// removes a new invalid filter from cache (permissions changed)
		public void InvalidateFilter(int userId)
		{
			someKindaCache.Remove(userId);
		}	
	}
