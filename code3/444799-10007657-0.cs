            _container = new WindsorContainer();
    
            IocModules.Configure(_container, new WcfConfigurationModule());
            IocModules.Configure(_container, new WcfAdapterModule());
            IocModules.Configure(_container, new ManagerModule());
            IocModules.Configure(_container, new FactoryModule());
    
            IBus bus = Configure.WithWeb()
                    .DefineEndpointName("OurProjectPublisher")
                    .DefiningEventsAs(t => t.Namespace != null && t.Namespace.StartsWith("MY.Bus.Contracts.Events"))
                    .CastleWindsorBuilder(_container)  // added here
                    .Log4Net()
                    .XmlSerializer()
                    .MsmqTransport()
                    .UnicastBus()
                    .CreateBus()
                    .Start(() => Configure.Instance.ForInstallationOn<NServiceBus.Installation.Environments.Windows>().Install());
            //_container.Register(Component.For<IBus>().Instance(bus).LifeStyle.Singleton);
