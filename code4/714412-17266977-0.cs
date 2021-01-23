    public sealed class CORStack<T>
    {
        Stack<StackFrame> _handlers;
        public CORStack(IObservable<T> source)
        {
            _handlers = new Stack<StackFrame>();
            _handlers.Push(new StackFrame(
                source.Select(t => new ShouldHandleWrapper(t, true)),
                new Handler<T>(new Action<T>(t => { }), true)));
        }
        public void Push(Handler<T> handler)
        {
            _handlers.Push(new StackFrame(_handlers.Peek().Observable, handler));
        }
        public Handler<T> Peek()
        {
            return _handlers.Peek().Handler;
        }
        public Handler<T> Pop()
        {
            var frame = _handlers.Pop();
            frame.Dispose();
            return frame.Handler;
        }
        class StackFrame : IDisposable
        {
            IDisposable _unsub;
            public IObservable<ShouldHandleWrapper> Observable { get; private set; }
            public Handler<T> Handler { get; private set; }
            public StackFrame(IObservable<ShouldHandleWrapper> topOfStack, Handler<T> handler)
            {
                _unsub = topOfStack.Subscribe(shouldHandle =>
                    {
                        if (shouldHandle.ShouldHandle)
                            handler.Action.Invoke(shouldHandle.Value);
                    });
                Observable = topOfStack.Select(shouldHandle =>
                    new ShouldHandleWrapper(shouldHandle.Value, shouldHandle.ShouldHandle && handler.Forward));
                Handler = handler;
            }
            public void Dispose()
            {
                _unsub.Dispose();
            }
        }
        class ShouldHandleWrapper
        {
            public readonly T Value;
            public readonly bool ShouldHandle;
            public ShouldHandleWrapper(T value, bool shouldHandle)
            {
                Value = value;
                ShouldHandle = shouldHandle;
            }
        }
    }
    public class Handler<T>
    {
        public Action<T> Action { get; set; }
        public bool Forward { get; set; }
        public Handler(Action<T> action, bool forward)
        {
            Action = action;
            Forward = forward;
        }
    }
