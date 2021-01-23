    public class LoggingUnityExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<ILogger, Logger>(new ContainerControlledLifetimeManager());
        }
    }
