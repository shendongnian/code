    var container = new UnityContainer();
    
    container.RegisterType<IConfig, ConfigA>("A");
    container.RegisterType<IConfig, ConfigA>("B");
    
    public class MainClass
    {
        private IConfig _config;
    
        public MainClass([Dependency("A")] IConfig config)
        {
            _config = config;
        }
    }
