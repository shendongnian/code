    public class ConsoleAppSynchronizationContext : SynchronizationContext, IDisposable
    {
        private Thread _thread;
        private Dispatcher _dispatcher;
        public ConsoleAppSynchronizationContext()
        {
            _thread = Thread.CurrentThread;
            _dispatcher = Dispatcher.CurrentDispatcher;
        }
        public override SynchronizationContext CreateCopy()
        {
            return new ConsoleAppSynchronizationContext()
                {
                    _thread =  _thread,
                    _dispatcher = _dispatcher
                };
        }
        public override void Send(SendOrPostCallback d, object state)
        {
            _dispatcher.Invoke(d, new []{ state });
        }
        public override void Post(SendOrPostCallback d, object state)
        {
            _dispatcher.BeginInvoke(d, new[] { state });
        }
        public void Dispose()
        {
            if (!_dispatcher.HasShutdownStarted && !_dispatcher.HasShutdownFinished)
                _dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
            GC.SuppressFinalize(this);
        }
        ~ConsoleAppSynchronizationContext()
        {
            Dispose();
        }
    }
