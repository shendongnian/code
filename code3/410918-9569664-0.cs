    public class TimeContext
    {
        private static TimeContext _instance;
    
        public static TimeContext Current
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DefaultContext();
                }
                return _instance;
            }
            set
            {
                if (value != null)
                {
                    _instance = value;
                }
            }
        }
        public abstract DateTime GetDateTime();
    }
