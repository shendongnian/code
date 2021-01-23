    var console = AsyncConsoleInput();
    var task = Task.Run(() =>
    {
         // your task on separate thread
    });
    if (Task.WaitAny(console.ReadLine(), task) == 0) // if ReadLine finished first
    {
        task.Wait();
        var x = console.Current.Result; // last user input (await instead of Result in async method)
    }
    else // task finished first 
    {
        var x = console.ReadLine(); // this wont issue another read line because user did not input anything yet. 
    }
