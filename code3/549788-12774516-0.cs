    var cache = Endpoint.AppHost.TryResolve<ICacheClient>();
    var typedSession = cache.SessionAs<CustomUserSession>(  //Uses Ext methods
        HttpContext.Current.Request.ToRequest(),  //ASP.NET HttpRequest singleton
        HttpContext.Current.Request.ToResponse()  //ASP.NET HttpResponse singleton
    );
