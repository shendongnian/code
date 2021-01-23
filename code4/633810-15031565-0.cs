    List<Task> tasks = new List<Task>();
    foreach (x...)
    {
        if (SomeCondition)
        {
            var someVariable = x;
            tasks.Add(Task.Factory.StartNew(() => SomeOtherMethod(someVariable));
         }
    }
    Task.WaitAll(tasks.ToArray());
