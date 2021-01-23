    var task = new Task(() => { throw new InvalidOperationException(); }, TaskCreationOptions.LongRunning);
    task.Start();
    try { task.Wait(); }
    catch { }
    
    if (task.IsFaulted)
    {
        // do something about the exception
        Console.WriteLine(task.Exception);
    }
