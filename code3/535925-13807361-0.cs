    internal sealed partial class Settings {
        
        public Settings() {
            SettingsProvider provider = CreateAnArbitraryProviderHere();
            // Try to re-use an existing provider, since we cannot have multiple providers
            // with same name.
            if (Providers[provider.Name] == null)
                Providers.Add(provider);
             else
                provider = Providers[provider.Name];
            // Change default provider.
            foreach (SettingsProperty property in Properties)
            {
                if (
                    property.PropertyType.GetCustomAttributes(
                        typeof(SettingsProviderAttribute),
                        false
                    ).Length == 0
                 )
                 {
                     property.Provider = provider;
                 }
             }
         }
    }
