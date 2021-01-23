    var subject = new Subject<int>();
    
    var onlyExceptions = subject.Materialize().Where(n => n.Exception != null).Dematerialize();
    
    subject.Subscribe(i => Console.WriteLine("Subscriber 1: {0}", i),
                        ex => Console.WriteLine("Subscriber 1 exception: {0}", ex.Message));
    
    onlyExceptions.Subscribe(i => Console.WriteLine("Subscriber 2: {0}", i),
                                ex => Console.WriteLine("Subscriber 2 exception: {0}", ex.Message));
    
    subject.OnNext(123);
    subject.OnError(new Exception("Test Exception"));
