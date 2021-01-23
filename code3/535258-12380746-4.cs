            IKernel nKernel = new StandardKernel();
            
            nKernel.Bind<IFoo>().To<Foo>();
            nKernel.Bind<IBar>().To<Bar>();
            nKernel.Bind<IBaz>().To<Baz>();
            nKernel.Bind<IContainer>().To<Container>();
            nKernel.Bind<IDependency>().ToConstant(new Dependency());            
            Container c = nKernel.Get<Container>();
            //utilize the container...
            nKernel.Unbind<IDependency>();
            nKernel.Bind<IDependency>().ToConstant(new Dependency());
            c = nKernel.Get<Container>();
            //utilize the container...
