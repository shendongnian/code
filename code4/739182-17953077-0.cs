    // In your original controller action
    HttpContext.Cache.Add("image-" + model.Id, model.ImageBytes, null,
        Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(1),
        CacheItemPriority.Normal, null);
    // In your view:
    <img src="@Url.Action("GetImage", "MyControllerName", new{fooId = Model.Id})">
    // In your controller:
    [OutputCache(VaryByParam = "fooId", Duration = 60)]
    public ActionResult GetImage(int fooId) {
        // Make sure you check for null as appropriate, re-pull from DB, etc.
        return File((byte[])HttpContext.Cache["image-" + fooId], "image/gif");
    }
