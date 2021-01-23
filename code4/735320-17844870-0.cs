    class SynchronousTaskScheduler : TaskScheduler
    {
        protected override void QueueTask(Task task)
        {
            this.TryExecuteTask(task);
        }
        protected override bool TryExecuteTaskInline(Task task, bool wasPreviouslyQueued)
        {
            return this.TryExecuteTask(task);
        }
        protected override IEnumerable<Task> GetScheduledTasks()
        {
            yield break;
        }
    }
