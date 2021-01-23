    class Controller : IDisposable // to dispose the unmanaged resources related to the hardware
    {
        // this will be used to call back to the UI
        private static readonly SynchronizationContext DefaultContext = new SynchronizationContext();
        
        public Controller()
        {         
            Task.Factory.StartNew(this.Monitor, ct, TaskCreationOptions.LongRunning);
        }
        public async Task<Result> ActionOnHardwareAsync(object parameter)
        {
            // you may need to synchronize with the monitor method here.  
        }
 
        // This method monitors hw status, calling back to the UI when something happens
        private void Monitor(object state)
        {
            // Do some stuffs...
            this.synchronizationContext.Post(~ your SendOrPostCallback here ~, ~ event from the hw ~);
        }
    }
