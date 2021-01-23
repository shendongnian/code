    public sealed class MyType
    {
        public MyType()
        {
            _initializationTask = InitializeAsync();
        }
        private Task _initializationTask;
        private async Task InitializeAsync()
        {
            // Asynchronously initialize this instance.
            _customers = await LoadCustomersAsync();
        }
         
        public async Task<Customer> LookupCustomer(string name)
        {
             // Waits to ensure the class has been initialized properly
             // The task will only ever run once, triggered initially by the constructor
             // If the task failed this will raise an exception
             // Note: there are no () since this is not a method call
             await _initializationTask;
             return _customers[name];
        }
        // one way of clearing the cache
        public void ClearCache()
        {
             InitializeAsync();
        }
        // another approach to clearing the cache, will wait until complete
        // I don't really see a benefit to this method since any call using the
        // data (like LookupCustomer) will await the initialization anyway
        public async Task ClearCache2()
        {
             await InitializeAsync();
        }
     }
