    public TReturn Get<TReturn>(string cacheId, Func<TReturn> getItemCallback)
        where TReturn : class
    {
        TReturn item = (TReturn)HttpRuntime.Cache.Get(cacheId);
        if (item == null)
        {
            item = getItemCallback();
            HttpContext.Current.Cache.Insert(cacheId, item);
        }
        return item;
    }
    return _cacheProvider.Get<List<LookupParameter>>(
      "", 
      ()=> _lookupTableRepository.GetAllLookupEntries(tableContext));
