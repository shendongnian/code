    public DataTable GetCities(bool BypassCache)
    {
       string cacheKey = "CitiesDataTable";
       object cacheItem = Cache[cacheKey] as DataTable;
       if((BypassCache) || (cacheItem == null))
       {
          cacheItem = GetCitiesFromDataSource();
          Cache.Insert(cacheKey, cacheItem, null,
          DateTime.Now.AddSeconds(GetCacheSecondsFromConfig(cacheKey), 
          TimeSpan.Zero);
       }
       return (DataTable)cacheItem;
    }
