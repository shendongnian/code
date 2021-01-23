    class Program
    {
        static void Main(string[] args)
        {
            ThreadManager.CurrentSession = 0;
            CreateWork objCreateWork = new CreateWork();
            for (int i = 0; i < 10; i++)
            {
                ThreadStart start = new ThreadStart(objCreateWork.ProcessQuickPLan);
                new Thread(start).Start();
            }
            Console.ReadLine();
        }
    }
    class CreateWork
    {
        private object CurrentSession = -1;
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
    class ThreadManager
    {
        public static object CurrentSession
        {
            get;
            set;
        }
    }
