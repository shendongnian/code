       var container = new WindsorContainer();
        container.Register(
            Component.For<IDataContext>().ImplementedBy<DataContext>(), // default datacontext
            Component.For<IService>().ImplementedBy<Service>(), // default service.
            Component.For<IDataContext>()
                 .ImplementedBy<DataContext>()
                 .LifestyleBoundTo<BoundContextUser>()
                 .Named("IDataContext_BoundContextUser"),                 
            Component.For<IDataContext>()
                 .ImplementedBy<DataContext>()
                 .LifestyleBoundTo<BoundContextUser2>()
                 .Named("IDataContext_BoundContextUser2"),
            Component.For<BoundContextUser>()
                 .LifestyleTransient()
                 .DependsOn(
                    Dependency.OnComponent(typeof(IDataContext),"IDataContext_BoundContextUser"),
                    Dependency.OnComponent(typeof(IService), "IService_BoundContextUser")),
            Component.For<BoundContextUser2>()
                 .DependsOn(
                    Dependency.OnComponent(typeof(IDataContext), "IDataContext_BoundContextUser2"),
                    Dependency.OnComponent(typeof(IService), "IService_BoundContextUser2"))
                 .LifestyleTransient(),
            
            Component.For<IService>()
                 .ImplementedBy<Service>()
                 .DependsOn(Dependency.OnComponent(typeof(IDataContext),"IDataContext_BoundContextUser"))
                 .LifestyleBoundTo<BoundContextUser>()
                 .Named("IService_BoundContextUser"),
            Component.For<IService>()
                 .ImplementedBy<Service>()
                 .DependsOn(Dependency.OnComponent(typeof(IDataContext), "IDataContext_BoundContextUser2"))
                 .LifestyleBoundTo<BoundContextUser2>()
                 .Named("IService_BoundContextUser2"),
            Component.For<UnboudContextUser>()
                 .LifestyleTransient()
            );
        var bound = container.Resolve<BoundContextUser>();
        var bound2 = container.Resolve<BoundContextUser2>();
        var unbound = container.Resolve<UnboudContextUser>();
        Assert.AreEqual(bound.DataContext, bound.Service.DataContext);
        Assert.AreEqual(unbound.DataContext, unbound.Service.DataContext);
        Assert.AreEqual(bound2.DataContext, bound2.Service.DataContext);
        Assert.AreNotEqual(bound.DataContext, bound2.DataContext);
