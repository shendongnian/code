    public class AsyncEventListener
    {
        private readonly Func<bool> _predicate;
    
        public AsyncEventListener() : this(() => true)
        {
            
        }
    
        public AsyncEventListener(Func<bool> predicate)
        {
            _predicate = predicate;
            Successfully = new Task(() => { });
        }
    
        public void Listen(object sender, EventArgs eventArgs)
        {
            if (_predicate.Invoke())
            {
                Successfully.RunSynchronously();
            }
        }
    
        public Task Successfully { get; }
    }
