    int test = 123;
    HttpContext.Current.Cache.Insert("key", test); 
    object cacheVal=HttpContext.Current.Cache.Get("key");
    if(cacheVal!=null)
        test = (int)HttpContext.Current.Cache.Get("key");
