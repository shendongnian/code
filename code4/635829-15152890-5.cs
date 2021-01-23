    public static void Register(HttpConfiguration config)
    {
        config.DependencyResolver   = new UnityDependencyResolver(
            new UnityContainer()
            .RegisterInstance<MyContext>(new MyContext())
            .RegisterType<AccountValidator>()
    
            .RegisterType<Controllers.AccountsController>()
        );
    
        config.Routes.MapHttpRoute(
            name:           "DefaultApi",
            routeTemplate:  "api/{controller}/{id}",
            defaults:       new { id = RouteParameter.Optional }
        );
    }
