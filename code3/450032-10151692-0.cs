    public ActionResult Foo()
    {
        string url = UrlHelper.GenerateUrl(
            null,                     // routeName
            "List",                   // actionName
            null,                     // controllerName
            null,                     // protocol
            null,                     // hostName
            "abc",                    // fragment <- that's what you are interested in
            null,                     // routeValues
            RouteTable.Routes,        // routeCollection
            Request.RequestContext,   // requestContext
            true                      // includeImplicitMvcValues
        );
        return Redirect(url);
    }
