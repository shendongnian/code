    public class ThreadManager
    {
        private int threadID { get; set; }
        public Dictionary<int, Thread> ThreadList { get; set; }
        public ThreadManager()
        {
            this.ThreadList = new Dictionary<int, Thread>();
        }
        public void LaunchThread(Action<string> SomeProcess, string s)
        {
            Thread thread = new Thread(() => SomeProcess(s));
            int id = threadID++;
            thread.Name = id.ToString();
            ThreadList.Add(id, thread);
            thread.Start();
        }
        public void KillThread()
        {
            ThreadList.Remove(Int32.Parse(Thread.CurrentThread.Name));
        }
    }
