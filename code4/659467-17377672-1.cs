    public class AppBootstrapper
        : UnityBootstrapper<ViewModels.AppViewModel>
    {
        protected override void Configure()
        {
            // register a 'singleton' instance of the app view model
            base.Container.RegisterInstance(
                new ViewModels.AppViewModel(), 
                new ContainerControlledLifetimeManager());
            // finish configuring for Caliburn
            base.Configure();
        }
    }
