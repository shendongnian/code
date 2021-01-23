    public void FooLogsCorrectly()
    {
        // Arrange
        var logMock = new Mock<ILog>();
        var logGenerator = new LogGenerator(logMock.Object);
        // Act
        logGenerator.Foo();
        // Assert
        logMock.Verify(m => m.WriteToLog("my log message"));
    }
