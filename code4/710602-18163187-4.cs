	// Setup cache
	SmartInstance<CacheDetails> cacheDetails;
	this.For<ICacheProvider<ISiteMap>>().Use<SessionStateCacheProvider<ISiteMap>>();
	var cacheDependency =
		this.For<ICacheDependency>().Use<NullCacheDependency>();
	cacheDetails =
		this.For<ICacheDetails>().Use<CacheDetails>()
			.Ctor<TimeSpan>("absoluteCacheExpiration").Is(absoluteCacheExpiration)
			.Ctor<TimeSpan>("slidingCacheExpiration").Is(TimeSpan.MinValue)
			.Ctor<ICacheDependency>().Is(cacheDependency);
