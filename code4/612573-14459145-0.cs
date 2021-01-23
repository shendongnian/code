    interface IIO
    {
        Task DoOperationAsync(); // note: no async here
    }
    
    class IOImplementation : IIO
    {
        public async Task DoOperationAsync()
        {
            // perform the operation here
        }
    }
