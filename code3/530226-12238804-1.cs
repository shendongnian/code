    public class ThreadingService
    {
        public Task FireAndForget(Action action)
        {
            return Task.Factory.StartNew(() => action.Invoke());
        }
    }
