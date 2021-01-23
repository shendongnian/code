    var listOfTasks = new List<Task>();
    for (int i = 0; i < 10; i++)
    {
        var count = i;
        // Note that we create the Task here, but do not start it.
        listOfTasks.Add(new Task(() => Something()));
    }
    Tasks.StartAndWaitAllThrottled(listOfTasks, 3);
