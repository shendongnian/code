    internal class WebConnectionProvider : IConnectionProvider {
        public string ConnectionString { get { return "Server=..."; } }
    }
    internal static class WebBootstrapper {
        public static void Init() {
            Bootstrapper.Init();
            ServiceLocator.AddSingleton<IConnectionProvider, WebConnectionProvider>();
        }
    }
