    public delegate Task AsyncEventHandler<T>(object sender, T args) where T : EventArgs;
    public class AsyncEvent : AsyncEvent<EventArgs>
    {
        public AsyncEvent() : base()
        {
        }
    }
    public class AsyncEvent<T> where T : EventArgs
    {
        private readonly HashSet<AsyncEventHandler<T>> _handlers;
        public AsyncEvent()
        {
            _handlers = new HashSet<AsyncEventHandler<T>>();
        }
        public void Add(AsyncEventHandler<T> handler)
        {
            _handlers.Add(handler);
        }
        public void Remove(AsyncEventHandler<T> handler)
        {
            _handlers.Remove(handler);
        }
        public async Task InvokeAsync(object sender, T args)
        {
            foreach (var handler in _handlers)
            {
                await handler(sender, args);
            }
        }
        public static AsyncEvent<T> operator+(AsyncEvent<T> left, AsyncEventHandler<T> right)
        {
            var result = left ?? new AsyncEvent<T>();
            result.Add(right);
            return result;
        }
        public static AsyncEvent<T> operator-(AsyncEvent<T> left, AsyncEventHandler<T> right)
        {
            left.Remove(right);
            return left;
        }
    }
