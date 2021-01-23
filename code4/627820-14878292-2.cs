    public sealed class UserSettings
    {
        private static readonly UserSettings _instance = new UserSettings();
        public static UserSettings Instance
        {
            get
            {
                return _instance;
            }
        }
        static UserSettings()
        {
        }
        private UserSettings()
        {
            // do constructor logic here
        }
    }
