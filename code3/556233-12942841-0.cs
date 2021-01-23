    int numConcurrentActions = 100000;
    BlockingCollection<Task> tasks = new BlockingCollection<Task>();
    
    Action someAction = () =>
    {
        dynamic dyn = new System.Dynamic.ExpandoObject();
    
        dyn.text = Get500kOfText() + Get500kOfText() 
            + DateTime.Now.ToString() + DateTime.Now.Millisecond.ToString();
    };
    
    //add a fixed number of tasks
    for (int i = 0; i < numConcurrentActions; i++)
    {
        tasks.Add(new Task(someAction));
    }
    
    //take a task out, set a continuation to add a new one when it finishes, 
    //and then start the task.
    foreach (Task t in tasks.GetConsumingEnumerable())
    {
        t.ContinueWith(_ =>
        {
            tasks.Add(new Task(someAction));
        });
        t.Start();
    }
