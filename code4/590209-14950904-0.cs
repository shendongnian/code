    public sealed class ExampleFixture
    {
        public static ExampleFixture Current = new ExampleFixture();
        private ExampleFixture()
        {
            // Run at start
        }
        ~ExampleFixture()
        {
            Dispose();
        }
        
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        
            // Run at end
        }        
    }
