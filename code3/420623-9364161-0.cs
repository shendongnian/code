    if (HttpContext.Current.Cache.Get("ef_results") == null)
    {
        var results = null; // todo: get results from EF
        HttpContext.Current.Cache.Add("ef_results", // cache key
                                      results, // cache value
                                      null, // dependencies
                                      System.Web.Caching.Cache.NoAbsoluteExpiration, // absolute expiration
                                      TimeSpan.FromMinutes(30)); // sliding expiration
    }
    myDropDown.DataSource = HttpContext.Current.Cache.Get("ef_results");
