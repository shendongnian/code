    public class ProgressReporter
    {
        private readonly TaskScheduler taskScheduler;
        public ProgressReporter(TaskScheduler taskScheduler)
        {
            this.taskScheduler = taskScheduler;
        }
        public Task RegisterContinuation(Task task, Action action)
        {
            return task.ContinueWith(n => action(), CancellationToken.None,
                TaskContinuationOptions.None, taskScheduler);
        }
        // Remaining members...
    }
