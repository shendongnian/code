    var cache = new Cache();
    // Add takes more parameters; fill whatever is necessary to make it work
    cache.Add("doSomeWorkCacheKey", doSomeWork, ...);
    var mockedHttpContextBase = new Mock<HttpContextBase>();
    // tell your mock to return pre-configured cache
    mockedHttpContextBase.Setup(m => m.Cache).Returns(cache);
    IHttpContextFactory httpContextFactory = new HttpContextFactory 
    { 
        Current = mockedHttpContextBase.Object 
    };
