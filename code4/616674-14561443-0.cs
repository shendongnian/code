    private static void SayHello(string s)
    {
        Task t = new Task(() => Console.WriteLine(s));
        t.Start();
    }
