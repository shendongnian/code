            var container = new UnityContainer();
            container
                .RegisterType<IRepository, Repository>()
                .RegisterType<IGateway, Gateway>( "FooGateway", new InjectionConstructor( "I am foo" ) )
                .RegisterType<IGateway, Gateway>( "BarGateway", new InjectionConstructor( "I am bar" ) )
                //.RegisterType<IServiceFoo, Service>( new InjectionConstructor( new ResolvedParameter<IRepository>(), new ResolvedParameter<IGateway>( "FooGateway" ) ) )
                //.RegisterType<IServiceBar, Service>( new InjectionConstructor( new ResolvedParameter<IRepository>(), new ResolvedParameter<IGateway>( "BarGateway" ) ) );
                .RegisterType<IServiceFoo>( new InjectionFactory( c => new Service( c.Resolve<IRepository>(), c.Resolve<IGateway>( "FooGateway" ) ) ) )
                .RegisterType<IServiceBar>( new InjectionFactory( c => new Service( c.Resolve<IRepository>(), c.Resolve<IGateway>( "BarGateway" ) ) ) );
