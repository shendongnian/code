    public class AutoMapperConfig
    {
        public static void RegisterConfig()
        {
            Mapper.Initialize(config => GetConfiguration(Mapper.Configuration));
        }
        private static void GetConfiguration(IConfiguration configuration)
        {
            configuration.AllowNullDestinationValues = true;
            configuration.AllowNullCollections = true;
            IEnumerable<Type> profiles = Assembly.GetExecutingAssembly().GetTypes().Where(type => typeof(Profile).IsAssignableFrom(type));
            foreach (var profile in profiles)
            {
                configuration.AddProfile(Activator.CreateInstance(profile) as Profile);
            }
        }
    }
