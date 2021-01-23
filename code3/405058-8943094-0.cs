     HttpRuntime.Cache.Insert(
                                        CacheKey,
                                        CacheValue,
                                        null,
                                        DateTime.Now.AddMinutes(CacheDuration),
                                        Cache.NoSlidingExpiration
                                    );
     Hashtable table1 = HttpRuntime.Cache[CacheKey] as Hashtable;
     HttpRuntime.Cache.Remove(CacheKey);
