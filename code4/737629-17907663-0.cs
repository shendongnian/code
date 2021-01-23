    public class SyncClass
    {
        public Thread[] thr;
        private int NumberOfWorkingThreads { get; set; }
        private object Sync = new object();
        public int ThreadNumber { get; private set; }
        public event EventHandler TasksFinished;
        public SyncClass(int threadNumber)
        {
            thr = new Thread[threadNumber];
            ThreadNumber = threadNumber;
            NumberOfWorkingThreads = ThreadNumber;
            //LunchThreads(threadNumber);
        }
        protected void OnTasksFinished()
        {
            if (TasksFinished == null)
                return;
            lock (Sync)
            {
                NumberOfWorkingThreads--;
                if (NumberOfWorkingThreads == 0)
                    TasksFinished(this, new EventArgs());
            }
        }
        public void LunchThreads()
        {
            string post = create_note();
            for (int i = 0; i < ThreadNumber; i++)
            {
                thr[i] = new Thread(() => invite(post));
                thr[i].IsBackground = true;                
                thr[i].Start();
            }
        }
        private void invite(string post)
        {
            while (true)
            {
                if (true)
                {
                    break;
                }
            }
            OnTasksFinished();
        }
       
    }
