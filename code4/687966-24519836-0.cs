    public class CustomCacheDependency : CacheDependency
    {
        //this method is called to expire a cache entry:
        public void ForceDependencyChange()
        {
            this.NotifyDependencyChanged(this, EventArgs.Empty);
        }
    }
    //this is how I add objects to cache:
    HttpContext.Current.Cache.Add(key, //unique key 
                obj, 
                CreateNewDependency(), //the factory method to allocate a dependency
                System.Web.Caching.Cache.NoAbsoluteExpiration,
                new TimeSpan(0, 0, ExpirationInSeconds),
                System.Web.Caching.CacheItemPriority.Default,
                ReportRemovedCallback);
    //A list that holds all the CustomCacheDependency objects:
    #region dependency mgmt
    private List<CustomCacheDependency> dep_list = new List<CustomCacheDependency>();
    private CustomCacheDependency CreateNewDependency()
    {
            CustomCacheDependency dep = new CustomCacheDependency();
            lock (dep_list)
            {
                dep_list.Add(dep);
            }
            return dep;
    }
    //this method is called to flush ONLY my cache entries in a thread safe fashion:
    private void FlushCache()
    {
            lock (dep_list)
            {
                foreach (CustomCacheDependency dep in dep_list) dep.ForceDependencyChange();
                dep_list.Clear();
            }
    } 
    #endregion
