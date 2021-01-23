            var container = new UnityContainer();
            container
                .RegisterType<IRepository, Repository>()
                .RegisterType<IGateway, Gateway>( "FooGateway", new InjectionConstructor( "I am foo" ) )
                .RegisterType<IGateway, Gateway>( "BarGateway", new InjectionConstructor( "I am bar" ) )
                .RegisterType<IServiceFoo, Service>( "sf", new InjectionConstructor( new ResolvedParameter<IRepository>(), new ResolvedParameter<IGateway>( "FooGateway" ) ) )
                .RegisterType<IServiceBar, Service>( "sb", new InjectionConstructor( new ResolvedParameter<IRepository>(), new ResolvedParameter<IGateway>( "BarGateway" ) ) );
                //.RegisterType<IServiceFoo>( new InjectionFactory( c => new Service( c.Resolve<IRepository>(), c.Resolve<IGateway>( "FooGateway" ) ) ) )
                //.RegisterType<IServiceBar>( new InjectionFactory( c => new Service( c.Resolve<IRepository>(), c.Resolve<IGateway>( "BarGateway" ) ) ) );
            var barGateway = container.Resolve<IGateway>( "BarGateway" );
            var fooGateway = container.Resolve<IGateway>( "FooGateway" );
            var serviceBar = container.Resolve<IServiceBar>( "sb" );
            var serviceBarGatewayName = serviceBar.DoSomething();
            var serviceFoo = container.Resolve<IServiceFoo>( "sf" );
            var serviceFooGatewayName = serviceFoo.DoSomething();
