    public int ApplicationShouldBeInstalled_Count { get; private set; }
    public bool ApplicationShouldBeInstalled(App app)
    {
        ApplicationShouldBeInstalled_Count++;
        ...
    }
