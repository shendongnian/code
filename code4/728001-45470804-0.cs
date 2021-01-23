    public sealed class LocalizationHandler
    {
       [ThreadStatic]
       private static ResourceManager _manager
       private readonly ConcurrentBag<ResourceManager> 
           _localizationIdentityCollection = new ConcurrentBag<ResourceManager>();
    
       private LocalizationHandler(){}
    
       public static LocalizationHandler Load(ResourceType source)
       {
          switch (source)
          {
              case typeA:
                  //check if resource exist in the concurrent bag or create a new one
               _manager = getManager();
               break;
          }
          return this;
       }
    
       public string Get(string key)
       {
           return _manager.Get(key)
       }
    }
