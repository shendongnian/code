    public ActionResult MyController()
    {
        var cache = HttpContext.Cache;
        var model = cache["key"];
        if (model == null) {
            model = GetData();
            cache.Insert(
               "key", 
               model, 
               null, 
               DateTime.Now.AddSeconds(30), 
               System.Web.Caching.Cache.NoSlidingExpiration);
        }
        return View(model);
    }
