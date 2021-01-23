    public interface IConfigurationProvider { }
    public class AzureConfigurationProvider : IConfigurationProvider { }
    public class LocalConfigurationProvider : IConfigurationProvider { }
    public static class ConfigurationProviderFactory
    {
        private static bool _isAzure = Microsoft.WindowsAzure.ServiceRuntime.RoleEnvironment.IsAvailable;
        private static Lazy<IConfigurationProvider> _provider = Lazy<IConfigurationProvider>(GetProvider);
    
        private static IConfigurationProvider GetProvider()
        {
             return _isAzure ?
                 new AzureConfigurationProvider() :
                 new LocalConfigurationProvider();
        }
        public static IConfigurationProvider Instance
        {
            get { return _provider.Value; }
        }
    }
