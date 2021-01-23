    var listOfActions = new List<Action>();
    for (int i = 0; i < 10000; i++)
    {
        // Note that we create the Action here, but do not start it.
        listOfActions.Add(() => DoSomething());
    }
 
    var options = new ParallelOptions {MaxDegreeOfParallelism = 10};
    Parallel.Invoke(options, listOfActions.ToArray());
