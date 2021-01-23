    _container.Register(
        Component
        .For<ISomeService>()
        .ImplementedBy<SomeService>()
        .AsWcfService(new RestServiceModel().Hosted())
        .AsWcfService(new DefaultServiceModel().Hosted()
            .PublishMetadata(mex => mex.EnableHttpGet())
            .AddEndpoints(
                WcfEndpoint.ForContract<ISomeService>().BoundTo(new WSHttpBinding())
            )
        )
    );
    RouteTable.Routes.Add(new ServiceRoute("v1/rest", new WindsorServiceHostFactory<RestServiceModel>(_container.Kernel), typeof(ISomeService)));
    RouteTable.Routes.Add(new ServiceRoute("v1/ws", new WindsorServiceHostFactory<DefaultServiceModel>(_container.Kernel), typeof(ISomeService)));
