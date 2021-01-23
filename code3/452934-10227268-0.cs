    [TestMethod]
    public void GetIDTest()
    {
        var windowTypeInfoMock = new Mock<IWindowTypeInfo>();
        windowTypeInfoMock.Setup(foo => foo.Name).Returns("Data");
        windowTypeInfoMock.Setup(foo => foo.UniqueID).Returns("someString");
        var lazyWindow =
             new Lazy<IWindowType, IWindowTypeInfo>(windowTypeInfoMock.Object);
    
        var WindowTypesList = new List<Lazy<IWindowType, IWindowTypeInfo>>();
        WindowTypesList.Add(lazyWindow);
    
        var a = new A();
        a.WindowTypes = WindowTypesList;
        var InfoMock = new Mock<Information>();
        InfoMock.Setup(foo => foo.TargetName).Returns("Data");
    
        string expected = "someString";
        string actual;
        actual = a.GetIdentifierForItem(InfoMock.Object);
        Assert.AreEqual(expected, actual);
    }
