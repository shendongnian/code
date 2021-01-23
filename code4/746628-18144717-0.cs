    class CreateWork
    {
        //private object CurrentSession = -1;   // boxed int
        static object CurrentSession = new object();
        public void ProcessQuickPLan()
        {
            lock (CurrentSession)
            {
                CurrentSession = ThreadManager.CurrentSession;
                Console.WriteLine(CurrentSession);
                ThreadManager.CurrentSession = Convert.ToInt32(ThreadManager.CurrentSession) + 1;
            }
        }
    }
