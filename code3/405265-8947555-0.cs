    public static class Bootstrapper
    {
        private static readonly IUnityContainer _container = new UnityContainer();
        public static void Initialize()
        {
            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(_container));
            _container.RegisterType<IDriverService, DriverService>();
        }
        public static void TearDown()
        {
            _container.Dispose();
        }
    }
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Bootstrapper.Initialize();
        }
        protected void Application_End(object sender, EventArgs e)
        {
            Bootstrapper.TearDown();
        }
    }
