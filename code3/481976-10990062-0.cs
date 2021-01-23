    ctx.Cache.Insert("cachename", () => condition? null : cacheValue, null,
        DateTime.Now.AddHours(
            Int32.Parse(siteViewModel.ApplicationSettings["CacheDurationHours"])),
        System.Web.Caching.Cache.NoSlidingExpiration,
        System.Web.Caching.CacheItemPriority.Default,
        null
    );
