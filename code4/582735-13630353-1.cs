    protected void Application_Start(object sender, EventArgs e) {
        var config = GlobalConfiguration.Configuration;
        config.Routes.MapHttpRoute(
            name: "CustomerOrdersHttpRoute",
            routeTemplate: "api/customers/{customerKey}/orders/{key}",
            defaults: new { controller = "CustomerOrders", key = RouteParameter.Optional },
            constraints: null,
            handler: new CustomerOrdersDispatcher(config)
        );
        config.MessageHandlers.Add(new SomeOtherHandler1());
        config.MessageHandlers.Add(new SomeOtherHandler2());
    }
