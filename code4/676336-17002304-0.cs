    public interface ITestExecutor
    {
       void RunTests(IEnumerable<string> sources, IRunContext runContext, IFrameworkHandle frameworkHandle);
       void RunTests(IEnumerable<TestCase> tests, IRunContext runContext, IFrameworkHandle frameworkHandle);
       void Cancel();
    }
