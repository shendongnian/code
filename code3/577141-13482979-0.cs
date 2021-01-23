    class PluginEngine : PluginEngineBase
    {
        public PluginSettings Settings
        {
            get
            {
                return (PluginSettings)base.Settings;
            }
            set
            {
                base.Settings = value;
            }
        }
    }
