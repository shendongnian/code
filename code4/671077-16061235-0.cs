    protected override void Initialize(RequestContext requestContext)
    {
        base.Initialize(requestContext);
        _sessionHelper = new HttpContextBaseSessionHelper(HttpContext);
    }
