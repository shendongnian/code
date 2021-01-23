    var config = new HttpSelfHostConfiguration("http://localhost:3000");
    config.Services.Replace(typeof(IAssembliesResolver), new AssembliesResolver());
    config.Routes.MapHttpRoute("default", "api/{controller}/{action}/{id}", new { id = RouteParameter.Optional });
    var server = new HttpSelfHostServer(config);
    server.OpenAsync().Wait();
