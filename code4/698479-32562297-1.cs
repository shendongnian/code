    [TestMethod]
    public void TestMethod1()
    {
        
     //// So that the web api project is loaded in-memory
     {webapi Project name}.Controller.{controllerName} = new {controller name}() ;
        HttpConfiguration config = new HttpConfiguration();
        config.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "api/{controller}/{id}",
            defaults: new {id = RouteParameter.Optional});
        HttpServer server = new HttpServer(config);
        HttpMessageInvoker client = new HttpMessageInvoker(server)
    }
