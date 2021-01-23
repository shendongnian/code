    public class AutoMapperConfiguration : IRequiresConfigurationOnStartUp
    {
        private readonly IContainer _container;
    
        public AutoMapperConfiguration(IContainer container)
        {
            _container = container;
        }
    
        public void Configure()
        {
            Mapper.Initialize(x => GetAutoMapperConfiguration(Mapper.Configuration));
        }
    
        private void GetAutoMapperConfiguration(IConfiguration configuration)
        {
            var profiles = GetProfiles();
            foreach (var profile in profiles)
            {
                configuration.AddProfile(_container.GetInstance(profile) as Profile);
            }
        }
    
        private static IEnumerable<Type> GetProfiles()
        {
            return typeof(AutoMapperConfiguration).Assembly.GetTypes()
                .Where(type => !type.IsAbstract && typeof(Profile).IsAssignableFrom(type));
        }
    }
