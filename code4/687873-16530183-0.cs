    class MyLock
    {
        private static bool _isLocked = false;
        private static object _objLock = new object();
    
        public bool Execute(Action a)
        {
            bool lockTaken = false;
            try
            {     
               Monitor.TryEnter(_objLock , ref lockTaken);
               if (_lockTaken)
               {
                   a();
               }
            }
            finally
            { 
               if (lockTaken)
               {
                 Monitor.Exit(lockObject);
               }
            }
            return lockTaken; 
        } 
    
    }   
