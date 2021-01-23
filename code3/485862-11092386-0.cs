    public static TResult GetFromCacheOrSource<TResult>(string cacheIndex, Func<TResult> sourceMethod)
    {
        TResult result = HttpContext.Current.Application[cacheIndex] as TResult;
        if (result == null)
        {
            // If there's no value in the cache go to the source
            result = sourceMethod();
        }     
        return result;
    }
