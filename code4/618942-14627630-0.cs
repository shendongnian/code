    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        filterContext.Result = new JsonResult
        {
            Data = "hello",
            JsonRequestBehavior = JsonRequestBehavior.AllowGet
        };
    }
