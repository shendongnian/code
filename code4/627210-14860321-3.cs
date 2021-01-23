    public void Bar()
    {
        try
        {
            semaphore.Wait();
            MethodA(param1, param2);
            MyDelegate del = new MyDelegate(MethodB);
            if (this.IsHandleCreated) this.Invoke(del);
        }
        finally
        {
            semaphore.Release();
        }
    }
