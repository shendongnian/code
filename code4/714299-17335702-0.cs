    public interface ICompletionState
    {
        public ITask Task { get; set; }
        public Exception Exception { get; set; }
    }
    public class CompletionState : ICompletionState
    {
        public ITask Task { get; set; }
        public Exception Exception { get; set; }
        public Action<ICompletionState> Callback { get; set; }
    }
    public class ProducerConsumerQueue
    {
        ConcurrentQueue<CompletionState> _tasks = new ConcurrentQueue<CompletionState>();
        
        public void EnqueueTask(ITask task, Action<ICompletionState> callback)
        {
            _tasks.Enqueue(new CompletionState{ Task = task, Callback = callback });
        }
        void Work()
        {                           
            while (true)
            {
                CompletionState cs;
                try
                {
                    if (!_tasks.TryDequeue(out cs))
                        continue;
                        
                    cs.Task.Execute();
                    cs.Callback(cs);
                }
                catch(Exception ex)
                {
                    cs.Exception = ex;
                    cs.Callback(cs);
                }
            }
        }
    }
