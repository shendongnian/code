    public sealed class Singleton
    {
        private static readonly object Instancelock = new object();
        private Singleton()
        {
        }
        private static Singleton instance = null;
    
        public static Singleton GetInstance
        {
            get
            {
                if (instance == null)
                {
                    lock (Instancelock)
                    {
                        if (instance == null)
                        {
                            instance = new Singleton();
                        }
                    }
                }
                return instance;
            }
        }
    }
