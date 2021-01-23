    public class Installer : IWindsorInstaller
    {
            public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
            {
                container.Register(
                    Component.For<IMyThingManager>().ImplementedBy<MyThingManager>(),
                    Component.For<IFooRepository>().ImplementedBy<FooRepository>()
                    );
            }
    }
