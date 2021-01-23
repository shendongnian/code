    public class RequestScheduler
    {
        private readonly BlockingCollection<Action> m_queue = new BlockingCollection<Action>();
        public RequestScheduler()
        {
            this.Start();
        }
        private void Start()
        {
            Task.Factory.StartNew(() =>
            {
                foreach (var action in m_queue.GetConsumingEnumerable())
                {
                    action();
                }
            }, TaskCreationOptions.LongRunning);
        }
        public Task<TResult> Schedule<TResult>(IOperation<TResult> operation)
        {
            var tcs = new TaskCompletionSource<TResult>();
            Action action = () =>
            {
                try
                {
                    tcs.SetResult(ProcessItem(operation));
                }
                catch (Exception e)
                {
                    tcs.SetException(e);
                }
            };
            m_queue.Add(action);
            return tcs.Task;
        }
        private T ProcessItem<T>(IOperation<T> operation)
        {
            // whatever
        }
    }
