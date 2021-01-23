    [Test]
    [TestCase("Fred", "Bloggs")]
    [TestCase("Joe", "Smith")]
    public void MyUnitTest(string firstName, string lastName)
    {
    }
    [TearDown]
    public void TearDown()
    {
        string firstName = TestContext.CurrentContext.Test.Arguments[0] as string;
        string lastName = TestContext.CurrentContext.Test.Arguments[1] as string;
    }
