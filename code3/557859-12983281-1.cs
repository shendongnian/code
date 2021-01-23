    string val = "foo";
    Context.Cache.Add(
                "someComplexObject",
                val,
                null,
                DateTime.Now.AddSeconds(seconds),
                System.Web.Caching.Cache.NoSlidingExpiration,
                System.Web.Caching.CacheItemPriority.NotRemovable,
                null
            );
    Response.Write(val.ToString());
