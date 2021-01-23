    protected void Application_Start(object sender, EventArgs e) {
        var config = GlobalConfiguration.Configuration;
        config.Routes.MapHttpRoute(
            "DefaultHttpRoute",
            "api/{controller}/{id}",
            new { id = RouteParameter.Optional }
        );
        config.MessageHandlers.Add(new MethodOverrideHandler());
    }
