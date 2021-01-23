    using Raven.Client;
    using Raven.Client.Embedded;
    
    namespace <YourNamespace>
    {
        public static class RavenConfig
        {
            public static IDocumentStore DocumentStore { get; private set; }
    
            public static void Register()
            {
                var store = new EmbeddableDocumentStore
                            {
                                UseEmbeddedHttpServer = true,
                                DataDirectory = @"~\App_Data\RavenDatabase", 
                                // or from connection string if you wish
                            };
                // set whatever port you want raven to use
                store.Configuration.Port = 8079;
                
                store.Initialize();
                DocumentStore = store;
            }
    
            public static void Cleanup()
            {
                if (DocumentStore == null)
                    return;
    
                DocumentStore.Dispose();
                DocumentStore = null;
            }
        }
    }
