    public class MyOwnServiceHostFactory: Castle.Facilities.WcfIntegration.DefaultServiceHostFactory
    {
        public MyOwnServiceHostFactory() : base(CreateKernel())
        { }
        private static Castle.MicroKernel.IKernel CreateKernel()
        {
            var container = new Castle.Windsor.WindsorContainer();
            container.Install(new WindsorInstaller());
            return container.Kernel;
        }
    }
    public class WindsorInstaller : IWindsorInstaller
    {
        #region IWindsorInstaller Members
        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            container.AddFacility<Castle.Facilities.WcfIntegration.WcfFacility>();
            container.AddFacility<Castle.Facilities.TypedFactory.TypedFactoryFacility>();
            container.Kernel.Resolver.AddSubResolver(new Castle.MicroKernel.Resolvers.SpecializedResolvers.ListResolver(container.Kernel));
            // add your services here...
        }
    }
