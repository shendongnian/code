    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Configuration;
    using System.Configuration.Internal;
    using System.Linq;
    using System.Reflection;
    namespace Williablog.Core.Configuration {
        public sealed class ConfigSystem: IInternalConfigSystem {
            private static IInternalConfigSystem clientConfigSystem;
            private object appsettings;
            private object connectionStrings;
            /// <summary>
            /// Re-initializes the ConfigurationManager, allowing us to merge in the settings from Core.Config
            /// </summary>
            public static void Install() {
                FieldInfo[] fiStateValues = null;
                Type tInitState = typeof(System.Configuration.ConfigurationManager).GetNestedType("InitState", BindingFlags.NonPublic);
                if (null != tInitState) {
                    fiStateValues = tInitState.GetFields();
                }
                FieldInfo fiInit = typeof(System.Configuration.ConfigurationManager).GetField("s_initState", BindingFlags.NonPublic | BindingFlags.Static);
                FieldInfo fiSystem = typeof(System.Configuration.ConfigurationManager).GetField("s_configSystem", BindingFlags.NonPublic | BindingFlags.Static);
                if (fiInit != null && fiSystem != null && null != fiStateValues) {
                    fiInit.SetValue(null, fiStateValues[1].GetValue(null));
                    fiSystem.SetValue(null, null);
                }
                ConfigSystem confSys = new ConfigSystem();
                Type configFactoryType = Type.GetType("System.Configuration.Internal.InternalConfigSettingsFactory, System.Configuration, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", true);
                IInternalConfigSettingsFactory configSettingsFactory = (IInternalConfigSettingsFactory) Activator.CreateInstance(configFactoryType, true);
                configSettingsFactory.SetConfigurationSystem(confSys, false);
                Type clientConfigSystemType = Type.GetType("System.Configuration.ClientConfigurationSystem, System.Configuration, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", true);
                clientConfigSystem = (IInternalConfigSystem) Activator.CreateInstance(clientConfigSystemType, true);
            }
            #region IInternalConfigSystem Members
            public object GetSection(string configKey) {
                // get the section from the default location (web.config or app.config)
                object section = clientConfigSystem.GetSection(configKey);
                switch (configKey) {
                    case "appSettings":
                        // Return cached version if exists
                        if (this.appsettings != null) {
                            return this.appsettings;
                        }
                        // create a new collection because the underlying collection is read-only
                        var cfg = new NameValueCollection();
                        // If an AppSettings section exists in Web.config, read and add values from it
                        if (section is NameValueCollection) {
                            NameValueCollection localSettings = (NameValueCollection) section;
                            foreach (string key in localSettings) {
                                cfg.Add(key, localSettings[key]);
                            }
                        }
                        // --------------------------------------------------------------------
                        // Here I read and decrypt keys and add them to secureConfig dictionary
                        // To test assume the following line is a key stored in secure sotrage.
                        //secureConfig = SecureConfig.LoadConfig();
                        secureConfig.Add("ACriticalKey", "VeryCriticalValue");
                        // --------------------------------------------------------------------                        
                        foreach (KeyValuePair<string, string> item in secureConfig) {
                            if (cfg.AllKeys.Contains(item.Key)) {
                                cfg[item.Key] = item.Value;
                            } else {
                                cfg.Add(item.Key, item.Value);
                            }
                        }
                        // --------------------------------------------------------------------                        
                        // Cach the settings for future use
                        this.appsettings = cfg;
                        // return the merged version of the items from secure storage and appsettings
                        section = this.appsettings;
                        break;
                    case "connectionStrings":
                        // Return cached version if exists
                        if (this.connectionStrings != null) {
                            return this.connectionStrings;
                        }
                        // create a new collection because the underlying collection is read-only
                        ConnectionStringsSection connectionStringsSection = new ConnectionStringsSection();
                        // copy the existing connection strings into the new collection
                        foreach (ConnectionStringSettings connectionStringSetting in ((ConnectionStringsSection) section).ConnectionStrings) {
                            connectionStringsSection.ConnectionStrings.Add(connectionStringSetting);
                        }
                        // --------------------------------------------------------------------
                        // Again Load connection strings from secure storage and merge like below
                        // connectionStringsSection.ConnectionStrings.Add(connectionStringSetting);
                        // --------------------------------------------------------------------                        
                        // Cach the settings for future use
                        this.connectionStrings = connectionStringsSection;
                        // return the merged version of the items from secure storage and appsettings
                        section = this.connectionStrings;
                        break;
                }
                return section;
            }
            public void RefreshConfig(string sectionName) {
                if (sectionName == "appSettings") {
                    this.appsettings = null;
                }
                if (sectionName == "connectionStrings") {
                    this.connectionStrings = null;
                }
                clientConfigSystem.RefreshConfig(sectionName);
            }
            public bool SupportsUserConfig { get { return clientConfigSystem.SupportsUserConfig; } }
            #endregion
        }
    }
