        public static List<CurrentProcess> Processes = new List<CurrentProcess>();
        [WebMethod]
        public static Guid StartProcess()
        {
            Mutex mutex = new Mutex();
            mutex.WaitOne();
            var star = Thread.CurrentThread.ManagedThreadId.ToString();
            var p = new CurrentProcess(Guid.NewGuid());
            Processes.Add(p);
            
            var o = Observable.Start(() =>
            {
                var cap = p;
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(2000);
                    var cp = Processes.FirstOrDefault(x => x.ID == cap.ID);
                    if (cp != null)
                        cp.Status = string.Format("Current Process ID: {0}, Iteration: {1}, Starting thread: {2}, Execution thread: {3}",
                            cp.ID.ToString(),
                            i.ToString(),
                            star,
                            Thread.CurrentThread.ManagedThreadId.ToString()
                            );
                }
                Processes.RemoveAll(x => x.ID == cap.ID);
            }, Scheduler.NewThread);
            mutex.ReleaseMutex();
            mutex.Close();
            return p.ID;
        }
        [WebMethod]
        public static string GetStatus(Guid processID)
        {
            var p = Processes.FirstOrDefault(x => x.ID == processID);
            if (p != null)
                return p.Status;
            return null;
        }
    }
    public class CurrentProcess
	{
        public Guid ID { get; set; }
        public string Status { get; set; }
        public CurrentProcess (Guid id)
	    {
            this.ID = id;
	    }
	}
