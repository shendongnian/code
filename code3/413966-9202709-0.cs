    using System;
    using System.Configuration;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Configuration.Provider;
    using System.Collections.Specialized;
    
    
        public abstract class DataProvider : ProviderBase
        {
            // Define the methods to be used by the provider.  These are custom methods to your own provider.
            public abstract void Get();
            public abstract void Delete();
        }
    
        public class DataProviderCollection : ProviderCollection { }
    
    
        
        
        //The name is typically the same as the abstract class, minus the Provider part. Sticking to our (fake) example. we'd have a static class called Data.
        public static class Data
        {
            private static bool _isInitialized = false;
    
            private static DataProvider _provider;
            public static DataProvider Provider
            {
                get
                {
                    Initialize();
                    return _provider;
                }
            }
    
            private static DataProviderCollection _providers;
            public static DataProviderCollection Providers
            {
                get
                {
                    Initialize();
                    return _providers;
                }
            }
    
            private static void Initialize()
            {
                DataProviderConfigurationSection dataConfig = null;
    
                if (!_isInitialized)
                {
                    // get the configuration section for the feature
                    dataConfig = (DataProviderConfigurationSection)ConfigurationManager.GetSection("data");
    
                    if (dataConfig == null)
                    {
                        throw new ConfigurationErrorsException("Data is not configured to be used with this application");
                    }
    
                    _providers = new DataProviderCollection();
    
                    // use the ProvidersHelper class to call Initialize() on each provider
                    ProvidersHelper.InstantiateProviders(dataConfig.Providers, _providers, typeof(DataProvider));
    
                    // set a reference to the default provider
                    _provider = _providers[dataConfig.DefaultProvider] as DataProvider;
    
                    _isInitialized = true;
                }
            }
    
            public static void Get()
            {
                Initialize();
                if (_provider != null)
                {
                    _provider.Get();
                }
            }
    
            public static void Delete()
            {
                Initialize();
                if (_provider != null)
                {
                    _provider.Delete();
                }
            }
        }
    
        public class MyDataProvider : DataProvider
        {
    
            
    
    
            public override void Get()
            {
                // Get Code
            }
    
            public override void Delete()
            {
                // Delete Code
            }
        }
    
        public class DataProviderConfigurationSection : ConfigurationSection
        {
            public DataProviderConfigurationSection()
            {
                _defaultProvider = new ConfigurationProperty("defaultProvider", typeof(string), null);
                _providers = new ConfigurationProperty("providers", typeof(ProviderSettingsCollection), null);
                _properties = new ConfigurationPropertyCollection();
    
                _properties.Add(_providers);
                _properties.Add(_defaultProvider);
            }
    
            private readonly ConfigurationProperty _defaultProvider;
            [ConfigurationProperty("defaultProvider")]
            public string DefaultProvider
            {
                get { return (string)base[_defaultProvider]; }
                set { base[_defaultProvider] = value; }
            }
    
            private readonly ConfigurationProperty _providers;
            [ConfigurationProperty("providers")]
            public ProviderSettingsCollection Providers
            {
                get { return (ProviderSettingsCollection)base[_providers]; }
            }
    
            private ConfigurationPropertyCollection _properties;
            protected override ConfigurationPropertyCollection Properties
            {
                get { return _properties; }
            }
        }
    
        public static class ProvidersHelper
        {
            private static Type providerBaseType = typeof(ProviderBase);
    
            /// <summary>
            /// Instantiates the provider.
            /// </summary>
            /// <param name="providerSettings">The settings.</param>
            /// <param name="providerType">Type of the provider to be instantiated.</param>
            /// <returns></returns>
            public static ProviderBase InstantiateProvider(ProviderSettings providerSettings, Type providerType)
            {
                ProviderBase base2 = null;
                try
                {
                    string str = (providerSettings.Type == null) ? null : providerSettings.Type.Trim();
                    if (string.IsNullOrEmpty(str))
                    {
                        throw new ArgumentException("Provider type name is invalid");
                    }
                    Type c = Type.GetType(str, true, true);
                    if (!providerType.IsAssignableFrom(c))
                    {
                        throw new ArgumentException(String.Format("Provider must implement type {0}.", providerType.ToString()));
                    }
                    base2 = (ProviderBase)Activator.CreateInstance(c);
                    NameValueCollection parameters = providerSettings.Parameters;
                    NameValueCollection config = new NameValueCollection(parameters.Count, StringComparer.Ordinal);
                    foreach (string str2 in parameters)
                    {
                        config[str2] = parameters[str2];
                    }
                    base2.Initialize(providerSettings.Name, config);
                }
                catch (Exception exception)
                {
                    if (exception is ConfigurationException)
                    {
                        throw;
                    }
                    throw new ConfigurationErrorsException(exception.Message,
                        providerSettings.ElementInformation.Properties["type"].Source,
                        providerSettings.ElementInformation.Properties["type"].LineNumber);
                }
                return base2;
            }
    
            public static void InstantiateProviders(ProviderSettingsCollection providerSettings, ProviderCollection providers, Type type)
            {
                foreach (ProviderSettings settings in providerSettings)
                {
                    providers.Add(ProvidersHelper.InstantiateProvider(settings, type));
                }
            }
        }
