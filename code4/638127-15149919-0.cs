    var s = new Semaphore(0, 4);
    s.Release(4);
    var wcs = new MyObject();
    var mutexs= new Mutex[4];
    for (int i = 0; i < wcs.Count(); ++i)
    {
        wcs[i] = new MyObject();
        mutexs[i] = new Mutex();
    }
    int counter = 0;
    Parallel.ForEach(ls, v =>
    {
        s.WaitOne();
        int index = -1;
        try
        {
            ++counter;
            Console.WriteLine("Counter = " + counter.ToString());
            MyObject wc = null;
            for (int i = 0; i < mutexs.Count(); ++i)
            {
                if(mutexs[i].WaitOne(0))
                {
                    index = i;
                    wc = wcs[i];
                    break; //Use only one Mutex per thread
                }
            }
            if (index == -1)
                throw new Exception("this triggers");
            //...
        }
        finally
        {
            --counter;
            mutexs[index].ReleaseMutex();
            s.Release();
        }
    });
