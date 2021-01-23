    public abstract class NeverEndingTask
    {
        // Using a CTS allows NeverEndingTask to "cancel itself"
        private readonly CancellationTokenSource _cts = new CancellationTokenSource();
        protected NeverEndingTask()
        {
             TheNeverEndingTask = new Task(
                () =>
                {
                    // Wait to see if we get cancelled...
                    while (!_cts.Token.WaitHandle.WaitOne(ExecutionLoopDelayMs))
                    {
                        // If we were cancelled, use the idiomatic way to terminate task
                        _cts.Token.ThrowIfCancellationRequested();
                        // Otherwise execute our code...
                        ExecutionCore(_cts.Token);
                    }
                },
                _cts.Token,
                TaskCreationOptions.DenyChildAttach | TaskCreationOptions.LongRunning);
            // Do not forget to observe faulted tasks - for NeverEndingTask faults are probably never desirable
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
           // Should throw if you try to start twice...
           TheNeverEndingTask.Start();
        }
        protected abstract void ExecutionCore(CancellationToken cancellationToken);
        public void Stop()
        {
            // This code should be reentrant...
            _cts.Cancel();
            TheNeverEndingTask.Wait();
        }
    }
