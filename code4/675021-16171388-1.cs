    var t1 = Task.Factory.StartNew( () => { throw new Exception(); } );
    var t2 = Task.Factory.StartNew( () => Console.WriteLine("Innocuous") );
    var t3 = Task.Factory.StartNew( () => { throw new Exception(); } );
    
    var t4 = Task.WhenAll(t1, t2, t3)
                 .ContinueWith(t => Console.WriteLine(t.Exception.InnerExceptions.Count), 
    			               TaskContinuationOptions.OnlyOnFaulted);
