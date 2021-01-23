    using System.Threading;
    private ManualResetEvent FixtureHandle = new ManualResetEvent(true);
    [SetUp]
    public void SetUp()
    {
        FixtureHandle.WaitOne();
    }
    [TearDown]
    public void TearDown()
    {
        FixtureHandle.Set();
    }
    [Test]
    public void Test1()
    {
      //only test
    }
    [Test]
    public void Test2()
    {
      //only test
    }
