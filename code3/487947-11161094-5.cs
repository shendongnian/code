    public class InitializingPluginManagerServiceDecorator
        : IPluginManagerService
    {
        private static readonly object syncRoot = new object();
        private static bool initialized;
        private IPluginManagerService decorated;
        private Container container;
        
        public InitializingPluginManagerServiceDecorator(
            IPluginManagerService decorated,
            Container container,
            IPluginToServiceProviderBridge serviceProvider)
        {
            this.pluginManagerService = pluginManagerService;
            this.container = container;
            this.serviceProvider = serviceProvider;
        }
        public void PluginManagerServiceMethod()
        {
            this.InitializeInLock();        
        
            this.decorated.PluginManagerServiceMethod();
        }
        
        private void InitializeInLock()
        {
            if (!initialized)
            {
                lock (syncRoot)
                {
                    if (!initialized)
                    {
                        this.InitializeInScope();
                    }
                }
                
                initialized = true;    
            }
        }
        
        private void InitializeInScope()
        {
            using (this.container.BeginLifetimeScope())
            {
                this.InitializeWithSave();
            }
        }
        
        private void InitializeWithSave()
        {
            var uow =
                this.container.GetInstance<IUnitOfWork>()
        
            var initializer = this.container
                .GetInstance<PluginManagerServiceInitializer>();
            
            initializer.Initialize();
            
            uow.Save();    
        }
    }
