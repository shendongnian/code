    string GetBarWithWait()
    {
        foo = new Foo();
        using (var mutex = new ManualResetEvent(false))
        {
            foo.Initialized += (sender, e) => 
            {
                try
                {
                    OnFooInit(sender, e);
                }
                finally
                {
                    mutex.Set();
                }
            }
            foo.Start();
            mutex.WaitOne();
        }
        return foo.Bar;
    }
