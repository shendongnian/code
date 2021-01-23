    if (HttpContext.Current != null)
    {
        Server.ClearError();
        Response.TrySkipIisCustomErrors = true;
        RouteData data = new RouteData();
        data.Values.Add("controller", "Error");
        data.Values.Add("action", "Error");
        IController controller = new MyApp.Controllers.ErrorController();
        controller.Execute(new RequestContext(new HttpContextWrapper(Context), data));
    }
