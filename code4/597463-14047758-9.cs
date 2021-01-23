    private ICacheService cacheProvider;
    protected override void Initialize(System.Web.Routing.RequestContext requestContext)
    {
        if (cacheProvider == null) cacheProvider = new InMemoryCache();
        base.Initialize(requestContext);
    }
