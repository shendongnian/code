    var itemsInCache= HttpContext.Current.Cache.GetEnumerator();
    
    while (itemsInCache.MoveNext())
    {
    
        HttpContext.Current.Cache.Remove(enumerator.Key);
    
    }
