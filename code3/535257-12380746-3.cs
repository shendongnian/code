            IKernel nKernel = new StandardKernel();
            
            Dependency d = new Dependency();
            nKernel.Bind<IDependency>().ToConstant(d);
            nKernel.Bind<IFoo>().To<Foo>();
            nKernel.Bind<IBar>().To<Bar>();
            nKernel.Bind<IBaz>().To<Baz>();
            nKernel.Bind<IContainer>().To<Container>();
            Container c = nKernel.Get<Container>();
