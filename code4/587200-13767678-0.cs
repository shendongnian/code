    class TaskExecutionQueue : ITaskExecutionQueue
    {
        private readonly Queue<Task> _queuedTasks = new Queue<Task>();
        private Task _currentTask;
        private readonly object _lockSync = new object();
        
        public Task<TResult> QueueTask<TResult>(Task<Task<TResult>> taskGenerator)
        {
            return QueueTaskCore(taskGenerator);
        }
        private Task<TResult> QueueTaskCore<TResult>(Task<Task<TResult>> taskGenerator)
        {
            lock (_lockSync)
            {
                Task<TResult> task = taskGenerator.Unwrap();
                task.ContinueWith(_ => StartNextTask());
                if (_currentTask == null)
                {
                    _currentTask = taskGenerator;
                    taskGenerator.RunSynchronously();
                    return task;
                }
                else
                {
                    TaskCompletionSource<TResult> tcs = new TaskCompletionSource<TResult>();
                    _queuedTasks.Enqueue(taskGenerator);
                    tcs.TrySetFromTaskIncomplete(task);
                    return tcs.Task;
                }
            }
        }
        private void StartNextTask()
        {
            lock (_lockSync)
            {
                _currentTask = null;
                if (_queuedTasks.Count > 0)
                {
                    Task next = _queuedTasks.Dequeue();
                    _currentTask = next;
                    next.RunSynchronously();
                }
            }
        }
        public int OutstandingTaskCount
        {
            get
            {
                lock (_lockSync)
                {
                    return _queuedTasks.Count;
                }
            }
        }
    }
