    [UseReporter(typeof(DebugReporter<FileLauncherReporter>))]
    public class SomeTests
    {
        [Test]
        public void test()
        {
            Approvals.Verify("Hello");
        }
    }
