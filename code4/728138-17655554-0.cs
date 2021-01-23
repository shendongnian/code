    var tasks = Enumerable
                  .Range(1, 10)
                  .Select(x => Task<int>.Run(() => x * 2))
                  .Select((x, i) => Task.Delay(TimeSpan.FromMilliseconds(i * 500))
                                        .ContinueWith(_ => x.Result));
              
    Task.WaitAll(tasks.ToArray());
    
    foreach(var result in tasks.Select(x => x.Result))
    {
        Console.WriteLine(result);
    }
