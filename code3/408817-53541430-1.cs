    SampleClass sampleObject = new SampleClass(); 
    Mock<log4net.ILog> logMockObject = new Mock<log4net.ILog>();
    sampleObject.Log = logMockObject.Object;
    sampleObject.DoStuffAndLogInfo();
    logMockObject.Verify(moqLog => moqLog.Info(It.IsAny<string>()), Times.AtLeastOnce()); 
