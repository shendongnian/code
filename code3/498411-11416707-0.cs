    public class TaskQueue : IDisposable
    {
        BlockingCollection<Action> taskX = new BlockingCollection<Action>();
        public TaskQueue(int taskCount)
        {
            // Create and start new Task for each consumer.
            for (int i = 0; i < taskCount; i++)
                Task.Factory.StartNew(Consumer);  
        }
        public void Dispose() { taskX.CompleteAdding(); }
        public void EnqueueTask (Action action) { taskX.Add(Action); }
        void Consumer()
        {
            // This seq. that we are enumerating will BLOCK when no elements
            // are avalible and will end when CompleteAdding is called.
            foreach (Action action in taskX.GetConsumingEnumerable())
                action(); // Perform your task.
        }
    }
