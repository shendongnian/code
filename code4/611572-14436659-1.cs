    var tasks = new List<Task>();
  
    if (condition) 
    { 
        var task = Task.Factory.StartNew (call the web service1...);
        tasks.Add(task);
    } 
    if (condition) 
    { 
        var task2 = Task.Factory.StartNew (call the web service2...);
         tasks.Add(task2);
    }
    if (condition) { 
        var task3 = Task.Factory.StartNew (call the web service3...); 
        tasks.Add(task3);
    }
    Task.WaitAll(tasks.ToArray());
