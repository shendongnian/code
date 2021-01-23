    public class Task
    {
        private Thread _thread;
        private bool _isRunning = true;
        public Task(Guid identity)
        {
            Identity = identity;
        }
        public event EventHandler DoWork;
        public readonly Guid Identity;
        public readonly Stopwatch Stopwatch = new Stopwatch();
        public void Run()
        {
            if (_thread != null)
            {
                throw new NotSupportedException("Thread is already started, can't be started twice");
            }
            _thread = new Thread(OnRun);
            _thread.Start();
        }
        private void OnRun()
        {
            Stopwatch.Start();
            try
            {
                while (_isRunning)
                {
                    if (DoWork != null)
                    {
                        DoWork(this, EventArgs.Empty);
                    }
                }
            }
            finally
            {
                Stopwatch.Stop();
            }
        }
        public void Stop(bool waitForThreadToDie = true)
        {
            _isRunning = false;
            if (waitForThreadToDie)
            {
                _thread.Join();
            }
            _thread = null;
        }
    }
