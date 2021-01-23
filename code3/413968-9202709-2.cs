        public abstract class DataProvider : ProviderBase
        {
    
            public string MyAttribute1 { get; set; }
            public string MyAttribute2 { get; set; }
            
            // Define the methods to be used by the provider.  These are custom methods to your own provider.
            public abstract void Get();
            public abstract void Delete();
        }
    
        public static class ProvidersHelper
        {
            ... 
            public static void InstantiateProviders(ProviderSettingsCollection providerSettings, ProviderCollection providers, Type type)
            {
                foreach (ProviderSettings settings in providerSettings)
                {
                    // Instantiate the provider.  We are expecting a DataProvider.
                    DataProvider provider = (DataProvider) ProvidersHelper.InstantiateProvider(settings, type);
    
                    // Get the additional attributes from the settings section. Do it via reflection, or explicitely.
                    // Check for any required fields, do type conversions, etc.  
                    provider.MyAttribute1 = settings.Parameters["MyAttribute1"];
                    provider.MyAttribute2 = settings.Parameters["MyAttribute2"];
                    
                    providers.Add(provider);
                }
            }
        }
