        var c = LongGetOrAdd(dict, 1);
        var t = Task.Factory.StartNew(() => c.Invoke(null));
    
        Task.WaitAll(task);
        Console.ReadLine();
