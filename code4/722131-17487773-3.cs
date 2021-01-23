    List<Task> tasks = new List<Task>();
    for (int i = 0; i <= input.Length/4; i += 2048)
    {
        // ...
        var test = Task.Factory.StartNew(() => addReferences(arrayToReference, iCopy));
        tasks.Add(test);
        // ...
    }
    Task.WaitAll(tasks);
