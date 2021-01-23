    public TestContext TestContext { get; set; }
    private List<string> GetProperties()
    {
        return TestContext.Properties
            .Cast<KeyValuePair<string, object>>()
            .Where(_ => _.Key.StartsWith("par"))
            .Select(_ => _.Value as string)
            .ToList();
    }
    
    //usage
    [TestMethod]
    [TestProperty("par1", "http://getbootstrap.com/components/")]
    [TestProperty("par2", "http://www.wsj.com/europe")]
    public void SomeTest()
    {
        var pars = GetProperties();
        //...
    }
