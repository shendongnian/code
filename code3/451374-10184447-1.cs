    protected override void OnActionExecuted(ActionExecutedContext filterContext)
    {
        // Put object back in cache in part to update any changes
        // but also to update the sliding expiration
        filterContext.HttpContext.Cache.Insert("userID", myObject, null, Cache.NoAbsoluteExpiration,
            TimeSpan.FromMinutes(20), CacheItemPriority.Normal, null);
    
        base.OnActionExecuted(filterContext);
    }
