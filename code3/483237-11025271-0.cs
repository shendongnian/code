    Component.For<IHelloWorldService>()
        .ImplementedBy<HelloWorldService>()
        .LifestyleTransient()
        .AsWcfService(
            new DefaultServiceModel()
                .AddBaseAddresses(baseAddress)
                .AddEndpoints(WcfEndpoint.BoundTo(new WSHttpBinding()).At("myBinding"))
                .PublishMetadata(o => o.EnableHttpGet())
        )
