    public class Service
    {
        public Service(ILog log) { ... }
    }
    var cb = new ContainerBuilder();
    cb.RegisterModule<LogInjectionModule>();
    cb.RegisterType<Service>();
    var c = cb.Build();
    var service = c.Resolve<Service>();
