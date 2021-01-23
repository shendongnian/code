    public class PrioritizedWorkQueue
    {
        List<Action> _queuedWork;
        object _queueLocker;
        Thread _workerThread;
        public PrioritizedWorkQueue()
        {
            _queueLocker = new object();
            _queuedWork = new List<Action>();
            _workerThread = new Thread(LookForWork);
            _workerThread.IsBackground = true;
            _workerThread.Start();
        }
        private void LookForWork()
        {
            while (true)
            {
                Action work;
                lock (_queueLocker)
                {
                    while (!_queuedWork.Any()) { Monitor.Wait(_queueLocker); }
                    work = _queuedWork.First();
                    _queuedWork.RemoveAt(0);
                }
                work();
            }
        }
        public void AddTask(Action task, bool highPriority)
        {
            lock (_queueLocker)
            {
                if (highPriority)
                {
                    _queuedWork.Insert(0, task);
                }
                else
                {
                    _queuedWork.Add(task);
                }
                Monitor.Pulse(_queueLocker);
            }
        }
    }
