    protected override void Initialize(System.Web.Http.Controllers.HttpControllerContext controllerContext)
    {
    	HttpContext.Current.Items["controllerContext"] = controllerContext;
    	base.Initialize(controllerContext);
    }
