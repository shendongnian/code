    public void Initialize(ClassB fixed)
    {
        Parallel.ForEach(itemCollection, item =>
        {
            this.InitializeStock(fixed, item);
        });
    }
