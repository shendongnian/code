    public override void OnAuthorization(AuthorizationContext authContext)
    {
        var folderId = authorizeContext.RouteData.Values["folderId"];
        ...
    }
