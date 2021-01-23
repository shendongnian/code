    class CreateWork
    {
        private object CurrentSession = -1;   // boxed int, Id only
        private static object _locker = new object();
        public void ProcessQuickPLan()
        {
            lock (_locker)
            {
                CurrentSession = ThreadManager.CurrentSession;
                Console.WriteLine(CurrentSession);
                ThreadManager.CurrentSession = Convert.ToInt32(ThreadManager.CurrentSession) + 1;
            }
        }
    }
