    internal sealed partial class Settings : ApplicationSettingsBase {
            
        private static Settings defaultInstance = 
            ((Settings)(ApplicationSettingsBase.Synchronized(
            new Settings())));
            
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
            
        [UserScopedSettingAttribute()]
        [DebuggerNonUserCode()]
        [DefaultSettingValueAttribute("if no user setting is present")]
        public string Setting {
            get {
                return ((string)(this["Setting"]));
            }
            set {
                this["Setting"] = value;
            }
        }
    }
