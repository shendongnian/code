    HttpContext.Current.Cache.Add(
        "mydatakey",        // key for retrieval
         MyDataObject,      
         null,              // cache dependencies
         DateTime.Now.AddDays(1),      // absolute expiration
         TimeSpan.FromDays(1),         // sliding expiration  
         System.Web.Caching.CacheItemPriority.NotRemovable,       // priority
         new CacheItemRemovedCallback(MyHandleRemovedCallback)
    );
