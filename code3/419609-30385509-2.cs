    [Test]
    public void ResolveByFactory()
    {
        WindsorContainer container = new WindsorContainer();
        container.AddFacility<TypedFactoryFacility>();
        container.Register(Component.For<IMyServiceFactory>().AsFactory());
        container.Register(Component.For<IMyService>().ImplementedBy<MyService>().LifestyleScoped());
        container.Register(Component.For<IDependency>().ImplementedBy<Dependency>().LifestyleScoped());
        IMyServiceFactory factory = container.Resolve<IMyServiceFactory>();
        IMyService myService1;
        IMyService myService2;
        
        using (container.BeginScope())
        {
            myService1 = factory.Create(new Data());
            myService2 = factory.Create(new Data());
            myService1.Should().BeSameAs(myService2);
        }
        using (container.BeginScope())
        {
            IMyService myService3 = factory.Create(new Data());
            myService3.Should().NotBeSameAs(myService1);
            myService3.Should().NotBeSameAs(myService2);
        }
    } 
