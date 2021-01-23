    private DirectoryInfo _directoryInfo;
    [SetUp]
    public void Setup()
    {
        _directoryInfo = new DirectoryInfo(_fakeInstallFolder);
        _directoryInfo.Refresh();
        if (_directoryInfo.Exists)
        {
            _directoryInfo.Delete(true);
            while (_directoryInfo.Exists)
                _directoryInfo.Refresh();
        }
        _controller = new ProjectController(ProjectType.CUSTOM, _fakeProjectName, _fakeInstallFolder);
    }
    [TearDown]
    public void TearDown()
    {
        _directoryInfo.Refresh();
        if (_directoryInfo.Exists)
        {
            _directoryInfo.Delete(true);
            while (_directoryInfo.Exists)
                _directoryInfo.Refresh();
        }
    }
