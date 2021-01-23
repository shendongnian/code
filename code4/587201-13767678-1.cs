    public interface ITaskExecutionQueue
    {
        Task<TResult> QueueTask<TResult>(Func<Task<TResult>> taskGenerator);
        Task<TResult> QueueTask<TResult>(Task<Task<TResult>> taskGenerator);
        int OutstandingTaskCount { get; }
        event EventHandler OutstandingTaskCountChanged;
    }
    /// This class ensures that only a single Task is executed at any one time.  They are executed sequentially in order being queued.
    /// The advantages of this class over OrderedTaskScheduler is that you can use any type of Task such as FromAsync (I/O Completion ports) 
    /// which are not able to be scheduled using a traditional TaskScheduler.
    /// Ensure that the `outer` tasks you queue are unstarted.  E.g. <![CDATA[
    /// _taskExeQueue.QueueTask(new Task<Task<TResult>>(() => StartMyRealTask()));
    /// ]]>
    class OrderedTaskExecutionQueue : ITaskExecutionQueue
    {
        private readonly Queue<Task> _queuedTasks = new Queue<Task>();
        private Task _currentTask;
        private readonly object _lockSync = new object();
        /// <summary>
        /// Queues a task for execution
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="taskGenerator">An unstarted Task that creates your started real-work task</param>
        /// <returns></returns>
        public Task<TResult> QueueTask<TResult>(Func<Task<TResult>> taskGenerator)
        {
            return QueueTask(new Task<Task<TResult>>(taskGenerator));
        }
        public Task<TResult> QueueTask<TResult>(Task<Task<TResult>> taskGenerator)
        {
            Task<TResult> unwrapped = taskGenerator.Unwrap();
            unwrapped.ContinueWith(_ =>
                                   {
                                       EndTask();
                                       StartNextTaskIfQueued();
                                   }, TaskContinuationOptions.ExecuteSynchronously);
            lock (_lockSync)
            {
                _queuedTasks.Enqueue(taskGenerator);
                if (_currentTask == null)
                {
                    StartNextTaskIfQueued();
                }
            }
            TaskCompletionSource<TResult> tcs = new TaskCompletionSource<TResult>();
            tcs.TrySetFromTaskIncomplete(unwrapped);
            OutstandingTaskCountChanged.Raise(this);
            return tcs.Task;
        }
        private void EndTask()
        {
            lock (_lockSync)
            {
                _currentTask = null;
                _queuedTasks.Dequeue();
            }
            OutstandingTaskCountChanged.Raise(this);
        }
        private void StartNextTaskIfQueued()
        {
            lock (_lockSync)
            {
                if (_queuedTasks.Count > 0)
                {
                    _currentTask = _queuedTasks.Peek();
                    _currentTask.RunSynchronously();
                }
            }
        }
        /// <summary>
        /// Includes the currently executing task.
        /// </summary>
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
        public event EventHandler OutstandingTaskCountChanged;
    }
