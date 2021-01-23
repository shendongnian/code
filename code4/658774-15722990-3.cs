    public class CaliburnMicroInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            // Register the window manager
            container.Register(Component.For<IWindowManager>().ImplementedBy<WindowManager>());
            // Register the event aggregator
            container.Register(Component.For<IEventAggregator>().ImplementedBy<EventAggregator>());
        }
    }
