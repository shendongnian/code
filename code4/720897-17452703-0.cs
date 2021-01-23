    protected override void Initialize(System.Web.Http.Controllers.HttpControllerContext controllerContext)
    {
        base.Initialize(controllerContext);
        // If the user is in a sensitive-data access role
        controllerContext.Configuration.Formatters.Add(/*My Formatter*/);
        // Otherwise use the default ones added in global app_start that defaults to remove sensitive data
    }
