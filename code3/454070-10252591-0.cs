    internal sealed class ProcessManager
    {
        private readonly IList<Process> processes;
        #region Singleton
        private static readonly object locker = new object();
        private static volatile ProcessManager instance;
        private ProcessManager()
        {
            processes = new List<Process>();
        }
        public static ProcessManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (locker)
                    {
                        if (instance == null)
                        {
                            instance = new ProcessManager();
                        }
                    }
                }
                return instance;
            }
        }
        #endregion
        public void AddProcess(Process process)
        {
            lock(processes)
            {
                processes.Add(process);
            }
        }
        public void TerminateAll()
        {
            lock(processes)
            {
                foreach (Process p in processes)
                {
                    try
                    {
                        p.Kill();
                        p.WaitForExit(); // possibly with a timeout
                    }
                    catch
                    {
                         continue;
                    }
                }
            }
        }
    }
