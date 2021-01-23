    public static IApplicationBuilder UseMvc(
        [NotNull] this IApplicationBuilder app,
        [NotNull] Action<IRouteBuilder> configureRoutes)
    {
        // Verify if AddMvc was done before calling UseMvc
        // We use the MvcMarkerService to make sure if all the services were added.
        MvcServicesHelper.ThrowIfMvcNotRegistered(app.ApplicationServices);
     
        var routes = new RouteBuilder
        {
            DefaultHandler = new MvcRouteHandler(),
            ServiceProvider = app.ApplicationServices
        };
     
        configureRoutes(routes);
     
        // Adding the attribute route comes after running the user-code because
        // we want to respect any changes to the DefaultHandler.
        routes.Routes.Insert(0, AttributeRouting.CreateAttributeMegaRoute(
            routes.DefaultHandler,
            app.ApplicationServices));
     
        return app.UseRouter(routes.Build());
    }
