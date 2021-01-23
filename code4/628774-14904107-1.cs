    public static void DoStuff()
    {
        Task<string> task = GetNameAsync();
        MainWorkOfApplicationIDontWantBlocked();
        // wait for the result
        string result = task.Result;
        // OR set up a continuation
        Task anotherTask = task.ContinueWith(r => {
                Console.WriteLine(r.Result);
            });
    }
