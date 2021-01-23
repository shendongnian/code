    public class SingleThreadedKillPredecssorScheduler
    {
        private Task current = Task.FromResult(true);
        private CancellationTokenSource cts = new CancellationTokenSource();
        private object key = new object();
        public Task Schedule(Action<CancellationToken> action)
        {
            lock (key)
            {
                cts.Cancel();
                cts = new CancellationTokenSource();
                current = current.ContinueWith(t => action(cts.Token), cts.Token);
                return current;
            }
        }
        public Task<T> Schedule<T>(Func<CancellationToken, T> function)
        {
            lock (key)
            {
                cts.Cancel();
                cts = new CancellationTokenSource();
                var next = current.ContinueWith(t => function(cts.Token), cts.Token);
                current = next;
                return next;
            }
        }
    }
