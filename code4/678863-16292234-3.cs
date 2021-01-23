    private Configuration()
    {
        InitTask = Init();
    }
    
    private async Task Init()
    {
        var contents = await FileIO.ReadTextAsync(file);
    }
    public Task InitTask { get; private set; }
