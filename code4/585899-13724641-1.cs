    public class Singleton : IDisposable
    {
        private readonly static Singleton _instance = new Singleton();
        private readonly static object lockObject = new object();
    
        static Singleton()
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
        /// <summary>
        /// Method that accesses the DB.
        /// </summary>
        public void DoWork()
        {
            lock (lockObject)
            {
                //Do Db work here. Only one thread can execute these commands at a time.                
            }
        }        
        ~Singleton()
        {
            //Close the connection to DB.
            //You don't want to make your singleton class implement IDisposable because
            //you don't want to allow a call to Singleton.Instance.Dispose().
        }
    }
