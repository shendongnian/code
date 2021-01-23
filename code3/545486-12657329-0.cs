    using System.Collections.ObjectModel;
    namespace WpfApplication1.Properties {
        
        
        [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
        internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
            
            private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
            
            public static Settings Default {
                get {
                    return defaultInstance;
                }
            }
    
            [global::System.Configuration.UserScopedSettingAttribute()]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public ObservableCollection<WpfApplication1.TestSettings.CheckedListItem<WpfApplication1.TestSettings.Customer>> Customers
            {
                get
                {
                    return ((ObservableCollection<WpfApplication1.TestSettings.CheckedListItem<WpfApplication1.TestSettings.Customer>>)(this["Customers"]));
                }
                set
                {
                    this["Customers"] = value;
                }
            }
        }
    }
