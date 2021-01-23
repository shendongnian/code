    var task1 = Task.Factory.StartNew (CallService(1));
    var task2 = Task.Factory.StartNew (CallService(2));
    var task3 = Task.Factory.StartNew (CallService(3));
    var continuation = Task.Factory.ContinueWhenAll(
        new[] { task1, task2, task3 }, tasks => Console.WriteLine("Done!"));
        
