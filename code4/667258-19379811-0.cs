    public class EndpointConfig : IConfigureThisEndpoint, IWantCustomInitialization, AsA_Server, UsingTransport<SqlServer>
    {
        public void Init()
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(GetAllAssemblies())
                .Where(t => t.GetCustomAttributes(typeof(ProviderAttribute), false).Any())
                .AsSelf()
                .AsImplementedInterfaces();
            Configure
                .With()
                .UseTransport<SqlServer>()
                .AutofacBuilder(builder.Build())
                .UseNHibernateTimeoutPersister()
                .UseNHibernateSagaPersister()
                .UnicastBus();
        }
        private static Assembly[] GetAllAssemblies()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return Directory.GetFiles(path, "*.dll").Select(Assembly.LoadFile).ToArray();
        }
    }
