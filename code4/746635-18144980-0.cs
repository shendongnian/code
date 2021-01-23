    using System;
    using System.Threading;
    class Program
    {
        static void Main(string[] args)
        {
            ThreadManager.CurrentSession = 0;
            for (int i = 0; i < 10; i++)
            {
                CreateWork objCreateWork = new CreateWork();
                ThreadStart start = new ThreadStart(objCreateWork.ProcessQuickPLan);
                new Thread(start).Start();
            }
            Console.ReadLine();
        }
    }
    
    class CreateWork
    {
        private static object _lock = new Object();
     
        public void ProcessQuickPLan()
        {
            lock (_lock)
            {            
                Console.WriteLine(ThreadManager.CurrentSession);
                ThreadManager.CurrentSession++;
            }
        }
    }
    
    class ThreadManager
    {
        public static int CurrentSession
        {
            get;
            set;
        }
    }
