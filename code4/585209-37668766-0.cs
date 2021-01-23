    public abstract class NeverEndingTask
    {
        private readonly CancellationTokenSource _cts = new CancellationTokenSource();
        protected NeverEndingTask()
        {
             TheNeverEndingTask = new Task(
                () =>
                {
                    while (!_cts.Token.WaitHandle.WaitOne(ExecutionLoopDelayMs))
                    {
                        _cts.Token.ThrowIfCancellationRequested();
                        ExecutionCore(_cts.Token);
                    }
                },
                _cts.Token,
                TaskCreationOptions.DenyChildAttach | TaskCreationOptions.LongRunning);
            TheNeverEndingTask.ContinueWith(x =>
            {
                Trace.TraceError(x.Exception.InnerException.Message);
                // Log/Fire Events etc.
            }, TaskContinuationOptions.OnlyOnFaulted);
        }
        protected readonly int ExecutionLoopDelayMs = 0;
        protected Task TheNeverEndingTask;
        public void Start()
        {
           TheNeverEndingTask.Start();
        }
        protected abstract void ExecutionLoop(CancellationToken cancellationToken);
        public void Stop()
        {
            _cts.Cancel();
            TheNeverEndingTask.Wait();
        }
    }
