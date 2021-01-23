    public interface CancellationTokenSourceWrapper : ICancellationTokenSource
    {
        private readonly CancellationTokenSource source;
    
        public CancellationTokenSourceWrapper(CancellationTokenSource source)
        {
            this.source = source;
        }
    
        public void Cancel() 
        {
            source.Cancel();
        }
    
    }
