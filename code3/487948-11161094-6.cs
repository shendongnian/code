    public class PluginManagerServiceInitializer
    {
        private IUnitOfWork unitOfWork;
        private IPluginToServiceProviderBridge serviceProvider;
        
        public PluginManagerServiceInitializer(
            IUnitOfWork unitOfWork,
            IPluginToServiceProviderBridge serviceProvider)
        {
            this.unitOfWork = unitOfWork;
            this.serviceProvider = serviceProvider;
        }
        
        public void Initialize()
        {
            var plugins =
                from plugin in this.serviceProvider.GetAllPlugins()
                select new PluginRecord
                {
                    interfaceType = plugin.InterfaceType;
                    var id = plugin.Id;
                    var version = plugin.Version;
                };
        
            unitOfWork.PluginsRepository.AddRange(plugins);
        }
    }
