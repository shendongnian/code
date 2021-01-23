    public static void StartThread(Action p)
    {
        Thread t = new Thread(p);
        t.Start();
    }
    ...
    StartThread(() => { Console.WriteLine("hello world"); });
