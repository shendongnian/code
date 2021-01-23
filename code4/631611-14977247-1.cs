    public class Class1
    {
        private ReaderWriterLockSlim methodLock = new ReaderWriterLockSlim();
        public static void Method1() 
        {
            methodLock.EnterWriteLock();
            try
            {
                //Body function
            }
            finally
            {
                methodLock.ExitWriteLock();
            }
        }
    
        public static void Method2() 
        {
             methodLock.EnterReadLock();
            try
            {
                //Body function
            }
            finally
            {
                methodLock.ExitReadLock();
            }
        }
    
        public static void Method3() 
        {
             methodLock.EnterReadLock();
            try
            {
                //Body function
            }
            finally
            {
                methodLock.ExitReadLock();
            }
        }
    }
