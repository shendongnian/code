    internal static class IntegrationTestHelper {
        internal static HttpConfiguration GetInitialIntegrationTestConfig() {
            var config = new HttpConfiguration();
            RouteConfig.RegisterRoutes(config.Routes);
            WebAPIConfig.Configure(config);
            
            return config;
        }
        internal static HttpConfiguration GetInitialIntegrationTestConfig(IContainer container) {
            var config = GetInitialIntegrationTestConfig();
            AutofacWebAPI.Initialize(config, container);
            return config;
        }
    }
