    var mutables = new List<Mutable> { new Mutable { X = 1 } };
    
    foreach (var m in mutables)
    {
        Console.WriteLine("Before change: {0}", m.X); // X = 1
        
        // We'll change loop variable directly without temporary variable
        m.ChangeX(10);
      
        Console.WriteLine("After change: {0}", m.X); // X = 10
    }
    
    foreach (var m in mutables)
    {
        // We start treating m as a pure read-only variable!
        Action a = () => Console.WriteLine(m.X));
    
        Console.WriteLine("Before change: {0}", m.X); // X = 1
        
        // We'll change a COPY instead of a m variable!
        m.ChangeX(10);
      
        Console.WriteLine("After change: {0}", m.X); // X = 1
    }
