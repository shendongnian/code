    var kernel = new StandardKernel();
    kernel.Bind<IFoo>().To<Foo>();
    kernel.Bind<IBar>().To<Bar>();
    kernel.Bind<IBaz>().To<Baz>();
    kernel.Bind<IContainerDependencies>().ToMethod(context =>
        {
            context.Kernel.Unbind<IDependency>();
            context.Kernel.Bind<IDependency>().ToConstant(new Dep());
            return context.Kernel.Get<ContainerDependencies>();
        });
     kernel.Bind<IContainer>().To<Container>();
