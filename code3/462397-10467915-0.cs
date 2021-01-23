    public class BaseSettings : ApplicationSettingsBase
    {
        protected BaseSettings(string settingsKey)
           { SettingsKey = settingsKey.ToLower(); }
        public override void Upgrade()
        {
             if (!UpgradeRequired)
                 return;
             base.Upgrade();
             UpgradeRequired = false;
             Save();
        }
        [SettingsProvider(typeof(MySettingsProvider)), UserScopedSetting]
        [DefaultSettingValue("True")]
        public bool UpgradeRequired
        {
             get { return (bool)this["UpgradeRequired"]; }
             set { this["UpgradeRequired"] = value; }
        }
    }
