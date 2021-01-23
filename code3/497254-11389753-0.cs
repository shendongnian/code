    public ActionResult Blah(string hash)
    {
        ... do something
        // Generate the url to redirect to using a hash
        var url = UrlHelper.GenerateUrl(
            null,                             // routeName
            "Foo",                            // actionName
            "Bar",                            // controllerName
            null,                             // protocol
            null,                             // hostName
            hash,                             // fragment
            null,                             // routeValues
            RouteTable.Routes,                // routeCollection
            ControllerContext.RequestContext, // requestContext
            false                             // includeImplicitMvcValues
        );
        return Redirect(url);
    }
