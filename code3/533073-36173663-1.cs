    public sealed class Singleton
    {
        private static readonly Object s_lock = new Object();
        private static Singleton instance = null;
    
        private Singleton()
        {
        }
    
        public static Singleton Instance
        {
            get
            {
                if(instance != null) return instance;
                Monitor.Enter(s_lock);
                Singleton temp = new Singleton();
                Interlocked.Exchange(ref instance, temp);
                Monitor.Exit(s_lock);
                return instance;
            }
        }
    }
