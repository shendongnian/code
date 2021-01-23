    public class BaseClass
    {
        protected static int P = 0;
        protected static object pLock = new object();
    }
    
    public class ChildClass<T> : BaseClass
    {
        private static int Q = 0;
        private static object qLock = new object();
    
        public void Inc()
        {
            lock(qLock)
            {
                qLock++;
            }
            lock(pLock)
            {
                qLock++;
            }
        }
    }
