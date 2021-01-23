    public class Singleton
    {
        private readonly static Singleton _instance = new Singleton();
    
        private static Singleton()
        {
        }
        private Singleton()
        {
            InitiateConnection();
        }
    
        public static Singleton Instance
        {
            get { return _instance; }
        }
    }
