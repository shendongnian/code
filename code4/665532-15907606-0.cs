    public sealed class MyType
    {
        public MyType()
        {
            Initialization = InitializeAsync();
        }
        public Task Initialization { get; private set; }
        private async Task InitializeAsync()
        {
            // Asynchronously initialize this instance.
            await Task.Delay(100);
        }
    }
