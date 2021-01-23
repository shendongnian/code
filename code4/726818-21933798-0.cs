    if( HttpRuntime.Cache.Get("dummy") == null )
    {
        HttpRuntime.Cache.Add("dummy", "==Username + CSRF TOKEN", null,
                            DateTime.Now.Add(TimeSpan.FromMinutes(30)),                 Cache.NoSlidingExpiration,
                                     CacheItemPriority.Normal,
                                     null);
     } else
     {
         var a = HttpRuntime.Cache.Get("dummy");
         Debug.WriteLine(a);
     }
