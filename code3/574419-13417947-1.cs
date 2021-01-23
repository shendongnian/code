    private readonly AsyncLazy<MyResource> resource;
    public MainPage()
    {
      resource = new AsyncLazy<MyResource>(async () =>
      {
        var a = await step0();
        var b = await step1();
        return new MyResource(a, b); // or whatever
      });
      resource.Start(); // start step0
    }
    public async Task MethodThatNeedsResource()
    {
      var r = await resource; // ensure step1 is complete before continuing
    }
