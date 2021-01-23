    public abstract class TestsBase : IDisposable
    {
        protected TestsBase()
        {
            // Do "global" initialization here
        }
        public void Dispose()
        {
            // Do "global" teardown here
        }
    }
    public class DummyTests : TestsBase
    {
        // Add test methods
    }
