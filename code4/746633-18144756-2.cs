    class CreateWork
    {
        private static readonly object LockObject = -1; // Although -1 works here, it's really misleading
        // You should consider replacing the above with a "plain" new object();
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
