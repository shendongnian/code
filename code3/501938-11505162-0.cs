    Console.WriteLine ("Start");
    Task task = Task.Factory.StartNew(() => {
    for (int i = 0; i < 5; i++)
    {
        Console.WriteLine (i);
    }
    });
    task.ContinueWith(ant =>
    {
        Console.WriteLine("End");
    }, TaskContinuationOptions.NotOnFaulted| TaskContinuationOptions.AttachedToParent);
