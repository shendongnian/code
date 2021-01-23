    class SomeClass
    {
        private Delegate handlers;
        public delegate void SomeEventDelegate<in T>(object sender, T data);
        public void AddSomeEventHandler<T>(SomeEventDelegate<T> handler)
        {
            this.handlers = Delegate.Combine(this.handlers, handler);
        }
        protected void OnSomeEvent<T>(T data)
        {
            if (this.handlers != null)
            {
                foreach (SomeEventDelegate<T> handler in
                    this.handlers.GetInvocationList().OfType<SomeEventDelegate<T>>())
                {
                    handler(this, data);
                }
            }
        }
    }
