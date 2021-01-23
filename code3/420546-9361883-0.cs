    List<Task> tasks = new List<Task>();
    Task.Factory.StartNew(() => DoAsync1()).ContinueWith(_ =>
    {
        foreach (MyClass myClass in Async1List)
        {
            tasks.Add(Task.Factory.StartNew(() => myClass.DoSomething()));
        }
        Task.WaitAll(tasks.ToArray());
    }).Wait();
    FinalAction();
