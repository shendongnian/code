    class Example
    {
        private Example()
        {
        }
        private async Task InitializeAsync()
        {
            // get the required data asynchronously here
        }
    
        public static async Task<Example> CreateAsync()
        {
            var result = new Example();
            await result.InitializeAsync();
            return resul;
        }
    }
