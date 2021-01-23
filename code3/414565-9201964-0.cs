    static readonly Semaphore semaphore = new Semaphore(1, 1);
    void Method1()
    {
        semaphore.WaitOne();
        try
        {
            // Do something ...
            new Thread(() =>
            {
                try
                {
                    // Do something else...
                }
                finally
                {
                    semaphore.Release();
                }
            }).Start();
        }
        catch (Exception)
        {
            semaphore.Release();
            throw;
        }
    }
