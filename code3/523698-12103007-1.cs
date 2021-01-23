    public AuthService AuthService
    {
        get
        {
            var authService = ServiceStack.WebHost.Endpoints.AppHostBase.Instance.Container.Resolve<AuthService>();
            authService.RequestContext = new HttpRequestContext(
                System.Web.HttpContext.Current.Request.ToRequest(),
                System.Web.HttpContext.Current.Response.ToResponse(),
                null);
            return authService;
        }
    }
