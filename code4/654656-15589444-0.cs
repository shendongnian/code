    var running = true;
    var values = new ConcurrentQueue<int>();
    var query = Observable.Create<int>(obs =>
    {
        var body = Task.Factory.StartNew(()=>
        {
            while(running)
            {
                int nextValue;
                if(values.TryDequeue(out nextValue))
                {
                    obs.OnNext(nextValue);
                }
                Thread.Yield();
            }
        });
        return Disposable.Create(() =>
        {
            try
            {
                running = false;
                body.Wait();
                obs.OnCompleted();            
            }
            catch(Exception ex)
            {
                obs.OnError(ex);
            }
        });
    });
    using(query.Subscribe(Console.WriteLine))
    {
        values.Enqueue(1);
        values.Enqueue(2);
        values.Enqueue(3);
        values.Enqueue(4);
        Console.ReadLine();
    }
