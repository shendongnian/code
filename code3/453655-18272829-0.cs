    public sealed class Settings
    {
        private static readonly Lazy<Settings> lazy =
        new Lazy<Settings>(() => new Settings());
        public static Settings Instance { get { return lazy.Value; } }
        private Settings()
        {
            _fileName = "Settings.ini";
        }
    ....
    }
