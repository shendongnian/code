    private string _expectedFile;
    [SetUp]
    public void SetUp()
    {
        _expectedFile = Path.Combine(
            Environment.GetEnvironmentVariable("ALLUSERSPROFILE"),
            "test.log");
        if (File.Exists(_expectedFile))
            File.Delete(_expectedFile);
        XmlConfigurator.Configure();
    }
    [Test] public void GivenLog4NetFileAppender_WhenLogInfoStringWithLog4Net_ThenWritesToDisk()
    {
        ILog log = LogManager.GetLogger(typeof (LoggingIntegrationTests));
        log.Info("Message from test");
        LogManager.Shutdown();
        Assert.That(File.ReadAllText(_expectedFile),
                    Is.StringContaining("Message from test"));
    }
