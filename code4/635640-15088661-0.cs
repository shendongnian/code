    filterContext.Result = new PartialViewResult
    {
        ViewData.Model = filterContext.HttpContext.Cache.Get("MyModelCache")[model.Name],
        ViewName = "~/Views/_NameOfPartial",
    };
