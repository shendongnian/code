    public sealed class ThrottledTask
        {
            private readonly object _runLock = new object();
            private readonly Func<Task> _runTask;
            private Task _loopTask;
            private int _updatePending;
    
            public ThrottledTask(Func<Task> runTask)
            {
                _runTask = runTask;
                AggregationPeriod = TimeSpan.FromMilliseconds(10);
            }
    
            public TimeSpan AggregationPeriod { get; private set; }
    
            public Task Run()
            {
                _updatePending = 1;
    
                lock (_runLock)
                {
                    if (_loopTask == null)
                        _loopTask = RunLoop();
                    
                    return _loopTask;
                }
            }
    
            private async Task RunLoop()
            {
                //Allow some time before we start processing, in case many requests pile up
                await Task.Delay(AggregationPeriod);
    
                //Continue to process as long as update is still pending
                //This clears flag on each cycle in a thread-safe way
                while (Interlocked.CompareExchange(ref _updatePending, 0, 1) == 1)
                {
                    await _runTask();
                }
             
                lock (_runLock)
                {
                    _loopTask = null;
                }
            }
        }
