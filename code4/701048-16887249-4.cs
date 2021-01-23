    var container = new WindsorContainer();
    
    container.AddFacility<TypedFactoryFacility>();
    container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel, true));
    
    container.Register(
        Component.For<IFoo>().Instance(new Foo("abc")).Named("abc"),
        Component.For<IFoo>().Instance(new Foo("123")).Named("123"),
        Component.For<Bar>().ImplementedBy<Bar>().
            DependsOn(ServiceOverride.ForKey("fooAbc").Eq("abc")).
            DependsOn(ServiceOverride.ForKey("foo123").Eq("123"))
        );
    
    var f = container.Resolve<Bar>();
