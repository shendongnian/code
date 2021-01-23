    public override void OnActionExecuting(ActionExecutingContext filterContext) {
	if (filterContext.HttpContext.Request.Url != null) {
		NameValueCollection urlQuery = System.Web.HttpUtility.ParseQueryString(filterContext.HttpContext.Request.Url.Query);
		for (int i = 0; i < urlQuery.Keys.Count; i++ )
		{
			if (urlQuery.Get(urlQuery[i]) == null)
			{
				filterContext.ActionParameters["word"] = urlQuery[i];
			}
		}
	}
	base.OnActionExecuting(filterContext);
