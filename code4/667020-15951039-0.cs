    protected internal virtual ViewResult View(string viewName, string masterName, object model)
    {
        if (model != null)
        {
            ViewData.Model = model;
        }
        return new ViewResult
        {
            ViewName = viewName,
            MasterName = masterName,
            ViewData = ViewData,
            TempData = TempData,
            ViewEngineCollection = ViewEngineCollection
         };
    }
