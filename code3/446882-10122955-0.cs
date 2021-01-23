    static class Program
    {
        static void Main()
        {
            var container = CreateContainer();
            ServiceBase.Run(container.Resolve<ServiceBase>());
        }
        private static IWindsorContainer CreateContainer()
        {
            var container = new WindsorContainer();
            container.Install(FromAssembly.This());
            return container;
        }
    }
    
    public class ServicesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container
                .AddFacility<WcfFacility>(f =>
                                              {
                                                  f.CloseTimeout = TimeSpan.Zero;
                                              })
                .Register(
                    Component.For<IVirusCheckService>().ImplementedBy<VirusCheckService>()
                        .LifeStyle.Transient
                        .AsWcfService(new DefaultServiceModel()
                                          .AddBaseAddresses("http://localhost:8080/MyService")
                                          .AddEndpoints(WcfEndpoint.BoundTo(new BasicHttpBinding())
                                                            .At("basic"))
                                          .PublishMetadata(o => o.EnableHttpGet())),
                    Component.For<ServiceBase>().ImplementedBy<MyService>());
        }
    }
    
