    protected void Configure()
    {
        ObjectFactory.Configure(x =>
        {
            x.Scan(scanner => scanner.AddAllTypesOf<IController>());
            // Skip using this
            // x.For<IAuthenticationService>()
            //    .Use(ServiceFactory.Create<IAuthenticationService>());
            // Use the IContext syntax instead. Normally you'd grab the instance out of the
            // container, but you can use this to resolve an instance "live" from
            // somewhere other than the container
            x.For<IAuthenticationService>()
                .Use(context => ServiceFactory.Create<IAuthenticationService>());
            x.For<IServiceContext>().Use<ServiceContext>();
        });
        // Remove this from production code because it resolves the entire container...
        ObjectFactory.AssertConfigurationIsValid();
    }
