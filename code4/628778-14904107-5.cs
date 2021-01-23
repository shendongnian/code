    public static void DoStuff()
    {
        Task<string> task = GetNameAsync();
        // Set up a continuation BEFORE MainWorkOfApplicationIDontWantBlocked
        Task anotherTask = task.ContinueWith(r => {
                Console.WriteLine(r.Result);
            });
        MainWorkOfApplicationIDontWantBlocked();
        // OR wait for the result AFTER
        string result = task.Result;
    }
