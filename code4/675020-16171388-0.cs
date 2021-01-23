    var t1 = Task.Factory.StartNew( () => { throw new Exception(); } );
    var t2 = Task.Factory.StartNew( () => { throw new Exception(); } );
    
    var t3 = Task.WhenAll(t1, t2)
                 .ContinueWith(t => Console.WriteLine(t.Exception.InnerExceptions.Count()), 
                               TaskContinuationOptions.OnlyOnFaulted);
