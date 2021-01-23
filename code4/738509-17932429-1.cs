    const int MAX_TASKS = 8;
    
    var numbers = Enumerable.Range(0, 10000000);
    
    IList<int> threadIds = new List<int>(MAX_TASKS);
    numbers.AsParallel()
           .WithDegreeOfParallelism(MAX_TASKS)
           .ForAll(i =>
            {
               var id = Thread.CurrentThread.ManagedThreadId;
               if (!threadIds.Contains(id))
               {
                   threadIds.Add(id);
               }
            });
    
     Assert.IsTrue(threadIds.Count > 2);
     Assert.IsTrue(threadIds.Count <= MAX_TASKS);
     Console.WriteLine(threadIds.Count);
