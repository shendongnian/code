       string cacheKey = GenerateCacheKey(myParam); //most likely a derivative of myParam
    
       if (Cache.IsInCache<MyResultType>(cacheKey))
       {
          return Cache.GetFromCache<MyResultType>(cacheKey);
       }
       
       var result = GetMyRequestedResult(myParam);
       if (result != null) //or whatever makes sense
       {
          Cache.InsertIntoCacheAbsoluteExpiration(cacheKey, result, DateTime.Now.AddMinutes(0));
       }
    
       return result;
