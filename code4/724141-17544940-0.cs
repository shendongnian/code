    List<ClassA> all = new List<ClassA> { ... };
    private async void Start()
    {
        foreach (var item in all)
        {
             await item.DoWork();
        }
    }
    public ClassA
    {
        public Task DoWork()
        {
            // Do work
        }
    }
