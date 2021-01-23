    private string[] commonCases = { "Val1", "Val2", "Val3" };
    [Test]
    [TestCaseSource(nameof(commonCases))]
    public void Test1(string value)
    {
        ....
    }
    [Test]
    [TestCaseSource(nameof(commonCases))]
    public void Test12(string value)
    {
        ....
    }
