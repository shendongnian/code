    public class MyUserSettings : ApplicationSettingsBase
    {
        [UserScopedSetting()]
        [DefaultSettingValue(0)]
        public int Rank
        {
            get
            {
                return (int)this["Score"];
            }
            set
            {
                this["Score"] = value;
            }
        }
    }
