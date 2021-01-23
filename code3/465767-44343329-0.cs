      public class CurrentThreadTaskScheduler : TaskScheduler
      {
        protected override void QueueTask(Task task)
        {
          TryExecuteTask(task);
        }
    
        protected override bool TryExecuteTaskInline(
           Task task,
           bool taskWasPreviouslyQueued)
        {
          return TryExecuteTask(task);
        }
    
        protected override IEnumerable<Task> GetScheduledTasks()
        {
          return Enumerable.Empty<Task>();
        }
    
        public override int MaximumConcurrencyLevel => 1;
      }
