    foreach (var mLoop in mutables)
    {
        // Introducing local variable!
        var m = mLoop;
       
        // We're capturing local variable instead of loop variable
        Action a = () => Console.WriteLine(m.X));
    
        Console.WriteLine("Before change: {0}", m.X); // X = 1
        
        // We'll roll back this behavior and will change
        // value type directly in the closure without making a copy!
        m.ChangeX(10); // X = 10 !!
      
        Console.WriteLine("After change: {0}", m.X); // X = 1
    }
