    [TestMethod]
    public void MyTestMethod()
    {
        var stub = new StubISeries();
        stub.KeyGet = () => SeriesKey.SomeKey1;
        Assert.AreEqual(SeriesKey.SomeKey1, ((ISeries)stub).Key);
    }
