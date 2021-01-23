    var task1 = Task.Factory.StartNew(() =>
    {
        Thread.Sleep(1000);
        return "dummy value 1";
    });
     
    var task2 = Task.Factory.StartNew(() =>
    {
        Thread.Sleep(2000);
        return "dummy value 2";
    });
     
    var task3 = Task.Factory.StartNew(() =>
    {
        Thread.Sleep(3000);
        return "dummy value 3";
    });
     
    Task.Factory.ContinueWhenAll(new[] { task1, task2, task3 }, tasks =>
    {
        foreach (Task<string> task in tasks)
        {
            Console.WriteLine(task.Result);
        }
    });
