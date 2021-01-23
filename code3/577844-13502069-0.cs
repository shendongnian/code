        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.RequestContext.HttpContext.Request.QueryString["MenuLayoutName"] != null && IsValidMenuLayoutName(filterContext.RequestContext.HttpContext.Request.QueryString["MenuLayoutName"] != null))
                ViewBag.MenuLayoutName = filterContext.RequestContext.HttpContext.Request.QueryString["MenuLayoutName"];
        }
