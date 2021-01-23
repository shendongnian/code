    public IEnumerable<MyType> ListCached
    {
        get { 
          DateTime latestModified = GetLatestModifiedDate();
          if(lastCache<latestModified) Cache = GetListFromDatabase();
          latestModified = DateTime.Now;
          return Cache.GetAll<MyType>();
        }
    }
