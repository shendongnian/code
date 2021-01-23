    [TestMethod]
    public void Test_DoSomething_logger()
    {
        //arrange
        var mockLog = new Mock<log4net.ILog>();
        var classWithLogger = new ClassWithLogger(mockLog.Object);
        mockLog.Setup(m => m.Debug(It.IsAny<string>()));
        mockLog.Setup(m => m.Fatal(It.IsAny<string>(), It.IsAny<Exception>()));
        //act1
        classWithLogger.DoSomething(new object());
        
        //assert1
        mockLog.Verify(l => l.Debug("called"), Times.Once());
        //act2
        classWithLogger.DoSomething();
        
        //assert2
        mockLog.Verify(x => x.Fatal("Exception raised!", It.IsAny<Exception>()));
    }
