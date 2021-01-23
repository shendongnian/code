    [Test] 
    public void GivenLog4NetFileAppender_WhenLogInfoStringWithLog4Net_ThenWritesToDisk()
    {
        // arrange
        ILog log = LogManager.GetLogger(typeof (LoggingIntegrationTests));
        string  = "Error 2";
    
        // act
        log.Info(dataToLog);
    
        // assert
        LogManager.Shutdown();
        var matches = Regex.Matches(File.ReadAllText(logfile), dataToLog);
        Assert.AreEqual(3, matches.Count);
    }
