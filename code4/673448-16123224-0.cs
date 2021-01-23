    public MainPage()
    {
        Initialization = InitializeAsync();
    }
    public Task Initialization { get; private set; }
    private async Task InitializeAsync()
    {
        Cache.Cache cache = new Cache.Cache();
        await cache.Initialization;
        NewsContent.InitializeData(cache.MyData);        
    }
