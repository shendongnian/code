    public class UserSettings
    {
        private static UserSettings _instance = new UserSettings();
        public static UserSettings Instance
        {
            get
            {
                return _instance;
            }
        }
        private UserSettings()
        {
            // do constructor logic here
        }
    }
