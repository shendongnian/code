    public sealed class Singleton
    {
        static Singleton instance=null;
        static readonly object padlock = new object();
    
        Singleton()
        {
        }
    
        public static Singleton Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance==null)
                    {
                        instance = new Singleton();
                    }
                    return instance;
                }
            }
        }
    }
