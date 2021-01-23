    // on appstart
    GlobalSessionFactory = CreateSessionFactory();
    // in basecontroller befor action
    protected override void OnActionExecuting(ActionExecutingContext filterContext)
    {
       base.OnActionExecuting(filterContext);
       DatabaseSession = GlobalSessionFactory.OpenSession();
    }
    // in basecontroller after action (pseudocode)
    protected override void OnActionExecuted()
    {
        DatabaseSession.Dispose();
    }
