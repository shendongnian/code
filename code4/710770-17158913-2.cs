    private IObservable<int> LoadData()
    {
        var ret = new Subject<int>();
        // Run something in the background
        Observable.Start(() => 
        {
            try 
            {
                for(int i=0; i < 100; i++) 
                {
                    // TODO: Replace with streaming items
                    ret.OnNext(10);
                    Thread.Sleep(100);
                }
                ret.OnCompleted();
            }
            catch (Exception ex) 
            {
                ret.OnError(ex);
            }
        }, RxApp.TaskpoolScheduler)
        return ret;
    }
