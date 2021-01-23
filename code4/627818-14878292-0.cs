    public class UserSettings
    {
        private static UserSettings _instance;
        public static UserSettings Instance
        {
            get
            {
                if (_instance == null) { _instance = new UserSettings(); }
                return _instance;
            }
        }
        private UserSettings()
        {
            // do constructor logic here
        }
    }
