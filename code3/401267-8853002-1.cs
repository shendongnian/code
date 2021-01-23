    [Test]
    public void MyMethod_DataProviderThrowsOutOfMemoryException_LogsError()
    {
        var dataProviderMock = new Mock<IDataProvider>();
        dataProviderMock
            .Setup(dp => dp.GetData())
            .Throws<OutOfMemoryException>();
        var myClass = new MyClass(dataProviderMock);
        
        myClass.MyMethod();
        // assert whatever needs to be checked
    }
