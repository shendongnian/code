    class JobProcessor<TInput, TOutput> : IDisposable
    {
        private readonly Func<TInput, TOutput> m_transform;
        // or a custom type instead of Tuple
        private readonly
            BlockingCollection<Tuple<TInput, TaskCompletionSource<TOutput>>>
            m_queue =
            new BlockingCollection<Tuple<TInput, TaskCompletionSource<TOutput>>>();
        public JobProcessor(Func<TInput, TOutput> transform)
        {
            m_transform = transform;
            Task.Factory.StartNew(ProcessQueue, TaskCreationOptions.LongRunning);
        }
        private void ProcessQueue()
        {
            Tuple<TInput, TaskCompletionSource<TOutput>> tuple;
            while (m_queue.TryTake(out tuple, Timeout.Infinite))
            {
                var input = tuple.Item1;
                var tcs = tuple.Item2;
                try
                {
                    tcs.SetResult(m_transform(input));
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
            }
        }
        public Task<TOutput> QueueJob(TInput input)
        {
            var tcs = new TaskCompletionSource<TOutput>();
            m_queue.Add(Tuple.Create(input, tcs));
            return tcs.Task;
        }
        public void Dispose()
        {
            m_queue.CompleteAdding();
        }
    }
