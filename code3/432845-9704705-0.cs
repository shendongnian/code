    public class Service
    {
        private ServiceConfig Config { get; set; }
        public class ServiceConfig
        {
        }
        public Service(ServiceConfig serviceConfig)
        {
            Config = serviceConfig;
        }
    
        ...
    }
