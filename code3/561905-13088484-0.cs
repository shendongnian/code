    private readonly Lazy<MyObject> myObject;
    public MyClass()
    {
        myObject = new Lazy<MyObject>(() =>
        {
            return MyService.LoadMyObject();
        }, LazyThreadSafetyMode.ExecutionAndPublication);
    }
    public bool IsModelLoaded
    {
        get { return myObject.IsValueCreated; }
    }
    public override MyObject Load()
    {
        return myObject.Value;
    }
