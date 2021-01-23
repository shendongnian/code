    public interface ITest
    {
        string Something { get; }
    }
    
    [Test]
    public void TestStub()
    {
        var mockery = new MockRepository();
        var testItem = mockery.Stub<ITest>();
        testItem.Something = "Hello";
        Assert.AreEqual("Hello", testItem.Something);
    }
