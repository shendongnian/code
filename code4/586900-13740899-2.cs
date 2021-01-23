    var g=  Task.Factory.StartNew<int> (() => 8)
           .ContinueWith (ant =>{throw null;})
           .ObserveExceptions()
           .ContinueWith (a =>{ Console.WriteLine("OK");});
    
     try{
          Console.WriteLine("1");
          g.Wait();
          Console.WriteLine("2");
         }
    
    catch (AggregateException  ex)
          {Console.WriteLine("catch"); }
