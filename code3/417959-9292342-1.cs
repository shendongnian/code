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
                    lock (typeof(Singleton))
                        if (_instance == null)
                        {
                            var instance = new Singleton();
                            _instance = instance;
                        }
                return _instance;
            }
        }       
    }
