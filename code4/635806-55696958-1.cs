static class ClassBeingTested
{
    public static void Method()
    {
        Trace.WriteLine("From Trace");
        Console.WriteLine("From Console");
        Console.Error.WriteLine("From Console Error");
    }
}
public class TestBaseSample  :
    XunitLoggingBase
{
    [Fact]
    public void Write_lines()
    {
        WriteLine("From Test");
        ClassBeingTested.Method();
        var logs = XunitLogger.Logs;
        Assert.Contains("From Test", logs);
        Assert.Contains("From Trace", logs);
        Assert.Contains("From Console", logs);
        Assert.Contains("From Console Error", logs);
    }
    public TestBaseSample(ITestOutputHelper output) :
        base(output)
    {
    }
}
