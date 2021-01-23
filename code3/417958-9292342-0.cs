    public sealed class Singleton
    {
        private static Singleton _instance { get; set; }
        private Singleton()
        {
        }
        public static Singleton Instance
        {
            get
            {
                if (_instance == null)
                    Instance = new Singleton();
                return _instance;
            }
        }       
    }
