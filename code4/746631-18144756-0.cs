    class CreateWork
    {
        private static object LockObject = -1;
        private object CurrentSession = -1;
        public void ProcessQuickPLan()
        {
            lock (LockObject)
            {
                CurrentSession = ThreadManager.CurrentSession;
                Console.WriteLine(CurrentSession);
                ThreadManager.CurrentSession = Convert.ToInt32(ThreadManager.CurrentSession) + 1;
            }
        }
    }
