    filterContext.Controller.ViewData.Model = 
        filterContext.HttpContext.Cache.Get("MyModelCache")[model.Name];
    filterContext.Result = new PartialViewResult
    {
        ViewData = filterContext.Controller.ViewData,
        ViewName = "~/Views/_NameOfPartial", // optional if you need it
    };
