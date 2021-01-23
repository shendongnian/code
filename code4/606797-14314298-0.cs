    public class Latch
    {
        private int count = 0;
        private readonly TaskCompletionSource<object> tcs =
            new TaskCompletionSource<object>();
        public void Increment()
        {
            Interlocked.Increment(ref count);
        }
        public void Decrement()
        {
            if (Interlocked.Decrement(ref count) == 0)
            {
                tcs.TrySetValue(null);
            }
        }
        public Task Task { get { return tcs.Task; } }
    }
