    public void MethodThree()
    {
        lock (MyLock)
        {
            MethodOne();
            MethodTwo();
        }
    }
