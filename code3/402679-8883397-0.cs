    var Authenticated = ... (the value that you already have)
    HttpContext.Current.Cache.Insert(
                        "myAuthenticatedCacheKey",
                        Authenticated,
                        null, DateTime.Now.AddMinutes(10), // 10 minutes expiration
                        System.Web.Caching.Cache.NoSlidingExpiration
                        );
