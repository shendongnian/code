    public class Singleton
    {
        private readonly static object _lockObject = new object();
        private static Singleton _instance;
        public static Singleton Instance {
            get
            {
                if (_instance == null)
                {
                    lock (_lockObject)
                    {
                        if (_instance == null)
                            _instance = new Singleton();
                    }
                }
                return _instance;
            }
        }
    }
