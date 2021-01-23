    using System;
    public sealed class Singleton
    {
        private static volatile Singleton instance;
        private static object syncRoot = new Object();
        private static ReaderWriterLockSlim cacheLock = new ReaderWriterLockSlim();
        private Singleton() {}
        public static Singleton Instance
        {
          get 
          {
             if (instance == null) 
             {
                lock (syncRoot) 
                {
                   if (instance == null) 
                      instance = new Singleton();
                }
             }
             return instance;
          }
        }
        public void WriteToFile(string value)
        {
            cacheLock.EnterWriteLock();
            try
            {
                // perform your file write here
            }
            finally
            {
                cacheLock.ExitWriteLock();
            }
        }
    }
