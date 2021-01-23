    public static class MyStack
    {
        private static readonly string name = Guid.NewGuid().ToString("N");
        private static ImmutableStack<string> CurrentContext
        {
            get
            {
                var ret = CallContext.LogicalGetData(name) as ImmutableStack<string>;
                return ret ?? ImmutableStack.Create<string>();
            }
            set
            {
                CallContext.LogicalSetData(name, value);
            }
        }
        public static IDisposable Push([CallerMemberName] string context = "")
        {
            CurrentContext = CurrentContext.Push(context);
            return new PopWhenDisposed();
        }
        private static void Pop()
        {
            CurrentContext = CurrentContext.Pop();
        }
        private sealed class PopWhenDisposed : IDisposable
        {
            private bool disposed;
            public void Dispose()
            {
                if (disposed)
                    return;
                Pop();
                disposed = true;
            }
        }
        // Keep this in your watch window.
        public static string CurrentStack
        {
            get
            {
                return string.Join(" ", CurrentContext.Reverse());
            }
        }
    }
