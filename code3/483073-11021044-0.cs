    protected void Application_Start(object sender, EventArgs e)
    {
	Dictionary<Datetime, string> pages = Read_from_database();
	Context.Cache.Insert("ExpireCache", pages, new CacheDependency(m_strPath),
		System.Web.Caching.Cache.NoAbsoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration,
		CacheItemPriority.Default);
    }
