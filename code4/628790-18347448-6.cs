    public static void DoStuff()
    {
        Task.Run(async () => GetNameAsync());
        MainWorkOfApplicationIDontWantBlocked();
    }
