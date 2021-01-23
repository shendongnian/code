    class CancellableTask<T>
    {
        private readonly Func<CancellationToken, T> m_computation;
        private readonly TimeSpan m_minumumRunningTime;
        private CancellationTokenSource m_cts;
        private Task<T> m_task;
        private DateTime m_startTime;
        public CancellableTask(Func<CancellationToken, T> computation, TimeSpan minumumRunningTime)
        {
            m_computation = computation;
            m_minumumRunningTime = minumumRunningTime;
        }
        public void Start()
        {
            m_cts = new CancellationTokenSource();
            m_task = Task.Factory.StartNew(() => m_computation(m_cts.Token), m_cts.Token);
            m_startTime = DateTime.UtcNow;
        }
        public T Result
        {
            get { return m_task.Result; }
        }
        public void CancelOrWait()
        {
            if (m_task.IsCompleted)
                return;
            TimeSpan remainingTime = m_minumumRunningTime - (DateTime.UtcNow - m_startTime);
            if (remainingTime <= TimeSpan.Zero)
                m_cts.Cancel();
            else
            {
                Console.WriteLine("Waiting for {0} ms.", remainingTime.TotalMilliseconds);
                bool finished = m_task.Wait(remainingTime);
                if (!finished)
                    m_cts.Cancel();
            }
        }
    }
