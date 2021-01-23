            IKernel nKernel = new StandardKernel();
            nKernel.Bind<IDependency>().To<Dependency>();
            nKernel.Bind<IFoo>().To<Foo>();
            nKernel.Bind<IBar>().To<Bar>();
            nKernel.Bind<IBaz>().To<Baz>();
            nKernel.Bind<IContainer>().To<Container>();
            Container c = nKernel.Get<Container>();
