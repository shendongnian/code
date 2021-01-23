    static string StartProcess()
    {
        // do stuff...
        return "some string";
    }
    // to be executed when the task completes
    static void WhenComplete(Task<string> task)
    {
        string result = task.Result;
        // do something with result
    }
    Task myTask = Task.Factory.StartNew<string>(StartProcess)
        .ContinueWith(WhenComplete);
    myTask.Wait(); // wait for everything to complete
