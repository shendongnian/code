    var initializer = new SafeInitializater(); //or you could make this static somewhere
    
    var t1 = Task.Run(() => 
    {
        Console.WriteLine($"Task {Task.CurrentId} entering the race");
        initializer.InitializeOnce(() => Console.WriteLine($"Task {Task.CurrentId} won!"));
    });
    var t2 = Task.Run(() => 
    {
        Console.WriteLine($"Task {Task.CurrentId} entering the race");
        initializer.InitializeOnce(() => Console.WriteLine($"Task {Task.CurrentId} won!"));
    });
    
    await Task.WhenAll(t1, t2);
