    public class EventAwaiter<TEventArgs>
    {
        #region Fields
        private TaskCompletionSource<TEventArgs> _eventArrived = new TaskCompletionSource<TEventArgs>();
        #endregion Fields
        #region Properties
        public Task<TEventArgs> Task { get; set; }
        public EventHandler<TEventArgs> Subscription => (s, e) => _eventArrived.TrySetResult(e);
        #endregion Properties
    }
