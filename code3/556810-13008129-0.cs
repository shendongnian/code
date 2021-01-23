    [Export(IPlugin)]
    public class Plugin
    {
        public Plugin()
        {
            var config = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
            var value = config.AppSettings.Settings["Key2"].Value;
        }
    }
