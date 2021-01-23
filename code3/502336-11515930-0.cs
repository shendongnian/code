    public class ApplicationPreload : IProcessHostPreloadClient
    {
        public void Preload(string[] parameters)
        {
            var repository = new MyRepositoryClass();
            HttpRuntime.Cache.Insert(
                "CollectionName", 
                repository.GetCollection(), 
                Cache.NoAbsoluteExpiration, 
                Cache.NoSlidingExpiration, 
                CacheItemPriority.NotRemovable, 
                null);
        }
    }
    
    public class MvcApplication : HttpApplication
    {
         public IEnumerable<CollectionItem> CollectionName
         {
             get { return HttpRuntime.Cache["CollectionName"] as IEnumerable<CollectionItem>; }
         }
    }
