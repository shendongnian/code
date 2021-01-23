    Console.WriteLine("Start Thread ID:{0}", Thread.CurrentThread.ManagedThreadId);
    var subscription = Observable.Create<double>(i => 
        {
            Console.WriteLine("Observable thread ID:{0}", Thread.CurrentThread.ManagedThreadId);
            while(true)
            {
                Console.WriteLine("Pushing values from thread {0}", Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(250);            
                i.OnNext(2.0);
            }
            return () => { };
        })        
        .SubscribeOn(Scheduler.TaskPool)   
        .ObserveOn(Scheduler.CurrentThread)
        .Subscribe(i =>
        {
            Console.WriteLine("Subscribable thread ID:{0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Inside Subscribe");
        });    
    Console.ReadLine();
    subscription.Dispose();
