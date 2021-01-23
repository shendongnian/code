    public static void DoStuff()
    {
        Task.Run(async () => await GetNameAsync());
        OtherCodeThatWillBeBlocked();
    }
