    public class AppHost : AppHostBase
    {
        public AppHost() : base("Hello ServiceStack!", typeof(ServicesFromDll1).Assembly) { }
        public override void Configure(Container container) {}
        //Provide Alternative way to inject IOC Container + Service Resolver strategy
        protected virtual ServiceManager CreateServiceManager(params Assembly[] assembliesWithServices)
        {       
            return new ServiceManager(new Container(),
                new ServiceController(() => assembliesWithServices.ToList().SelectMany(x => x.GetTypes())));
        }
    }
