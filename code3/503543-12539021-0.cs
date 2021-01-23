    public abstract class TestBase
    {
        [Fact]
        public void Verify()
        {
            // Step 1
            // Step 2
            // Overridable step 3
            DoStuff();
            // Assert
        }
        protected abstract void DoStuff();
    }
    public class Test1 : TestBase
    {
        protected override void DoStuff()
        {
            // Test1 variation
        }
    }
    public class Test2 : TestBase
    {
        protected override void DoStuff()
        {
            // Test2 variation
        }
    }
