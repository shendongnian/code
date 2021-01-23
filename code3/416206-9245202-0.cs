    [Test]
    public void TestCopy()
    {
        var viewMock = A.Fake<IView>();
        A.CallTo(() => viewMock.Copy).Returns("Testing ...");
        Assert.AreEqual("Testing ...", viewMock.Copy);
    }
