    public class Singleton<T> where T : class, new()
    {
        private static object sync = null;
        private static volatile T i;
        protected Singleton() { }
        public static T I
        {
            get
            {
                if (i == null)
                    lock (sync)
                        if (i == null)
                            i = new T();
                return i;
            }
        }
    }
