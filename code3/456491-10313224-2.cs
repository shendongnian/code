    public static void StartThread(string s)
    {
        Thread t = new Thread(() => { Console.WriteLine(s); });
        t.Start();
    }
