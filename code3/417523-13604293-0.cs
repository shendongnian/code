    class LocalizedTaskScheduler : TaskScheduler
    {
        public CultureInfo Culture { get; set; }
        public CultureInfo UICulture { get; set; }
        #region Overrides of TaskScheduler
        protected override void QueueTask(Task task)
        {
            //Queue the task in the thread pool
            ThreadPool.UnsafeQueueUserWorkItem(_ =>
                                                   {
                                                       //Adjust the thread culture
                                                       Thread.CurrentThread.CurrentCulture = this.Culture;
                                                       Thread.CurrentThread.CurrentUICulture = this.UICulture;
                                                       //Execute the task
                                                       TryExecuteTask(task);
                                                   }, null);
        }
        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            if (taskWasPreviouslyQueued)
            {
                return false;
            }
            // Try to run the task. 
            return base.TryExecuteTask(task);
        }
        protected override IEnumerable<Task> GetScheduledTasks()
        {
            //We have no queue
            return Enumerable.Empty<Task>();
        }
        #endregion
    }
