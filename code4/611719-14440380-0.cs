    [TestFixture]
    public MyTests()
    {
        [TestFixtureSetUp]
        public void Init()
        {
            System.Thread.Sleep(5000);
        }
        ...
    }
