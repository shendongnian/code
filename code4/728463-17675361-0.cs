    public class MyTaskScheduler : TaskScheduler
    {
        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            if (this.CanInlineTasks() ||    // should return true most of the time
                IsSynchronousContinuationTask(task))
                return base.TryExecuteTaskInline(task, taskWasPreviouslyQueued);
                
            return false; 
        }
        private static bool IsSynchronousContinuationTask(Task task)
        {
            // assuming Mono
            string stackTrace = Environment.StackTrace;
            return stackTrace.Contains("System.Threading.Tasks.Task.RunSynchronouslyCore") 
                && stackTrace.Contains("System.Threading.Tasks.TaskContinuation.Execute");
        }
    }
