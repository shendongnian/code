    public override void OnAuthorization(AuthorizationContext filterContext)
    {
        var folderId = filterContext.RouteData.Values["folderId"];
        ...
    }
