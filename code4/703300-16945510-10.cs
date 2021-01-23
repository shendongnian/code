    private readonly SemaphoreSlim globalLock = new SemaphoreSlim(1));
    ...
    public void SaveValue()
    {
        string val = GetValueFromDB();
        MyClass thisValue;
        globalLock.Wait();
        try
        {
            if (this.GlobalValue == NULL)
            {
                this.GlobalValue = new MyClass(val);
            }
            else if (this.GlobalValue.Key != val)
            {
                this.GlobalValue = new MyClass(val);
            }
            thisValue = this.GlobalValue
        }
        finally
        {
            globalLock.Release();
        }
        string result = thisValue.GetData();
    }
