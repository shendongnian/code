            Info info = null;
        if (HttpRuntime.Cache["Info_" + id.ToString() + "_" + quantity.ToString()] != null)
            info = HttpRuntime.Cache["Info_" + id.ToString() + "_" + quantity.ToString()] as Info;
        if (info == null)
        {
            info = (from dd in dc.Infos
                              where dd.id == id && dd.active == true && dd.quantitytooffset == quantity
                              select dd).SingleOrDefault();
            if (info != null)
            {
                HttpRuntime.Cache.Add("Info_" + id.ToString() + "_" + quantity.ToString(), info, null, System.Web.Caching.Cache.NoAbsoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.High, null);
            }
        }
