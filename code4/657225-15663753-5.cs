    private void Mock<ILogger> _mockLogger = null;
    public void Load()
    {
        this._mockLogger = new Mock<ILogger>();
        LoggerFactory.Logger = _mockLogger.Object;
    }
    public void UnitTest()
    {
        // test as required
        this._mockLogger.Verify(m => m.Log(It.IsAny<string>()));
    }
