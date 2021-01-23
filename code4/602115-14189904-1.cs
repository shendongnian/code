    public MyConstructor()
    {
      Initialized = InitializeAsync();
    }
    public Task Initialized { get; private set; }
    private async Task InitializeAsync()
    {
      // asynchronous initialization here
    }
