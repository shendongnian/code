    public class TaskTracker
    {
        private readonly Action<CancellationToken> OnDoWork;
        private readonly CancellationTokenSource TokenSource;
        private readonly CancellationToken Token;
        private bool _isRunning;
        private Task _task;
        public TaskTracker(Guid identity, Action<CancellationToken> onDoWork)
        {
            TokenSource = new CancellationTokenSource();
            Token = TokenSource.Token;
            Identity = identity;
            OnDoWork = onDoWork;
        }
        public readonly Guid Identity;
        public readonly Stopwatch Stopwatch = new Stopwatch();
        public event EventHandler TaskExiting;
        public void Start()
        {
            _isRunning = true;
            _task = Task.Factory.StartNew(
                () =>
                    {
                        Stopwatch.Start();
                        try
                        {
                            while (_isRunning)
                            {
                                OnDoWork(Token);
                            }
                        }
                        finally
                        {
                            Stopwatch.Stop();
                            if (TaskExiting != null)
                            {
                                TaskExiting(this, EventArgs.Empty);
                            }
                        }
                    }, Token
                );
        }
        public void Stop(bool waitForTaskToExit = false)
        {
            if (_task == null)
            {
                throw new InvalidOperationException("Task hasn't been started yet");
            }
            _isRunning = false;
            if (waitForTaskToExit)
            {
                _task.Wait();
            }
            _task = null;
        }
        public void Cancel()
        {
            if (_task == null)
            {
                throw new InvalidOperationException("Task hasn't been started yet");
            }
            _isRunning = false;
            TokenSource.Cancel();
            _task = null;
        }
    }
