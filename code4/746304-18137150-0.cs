    private void DoStuff()
    {
        CreateTimer();
        Console.WriteLine("Timer started");
        int count = 0;
        for (int x = 0; x < 1000000; ++x)
        {
            string s = new string("just trying to exercise the garbage collector".Reverse().ToArray());
            count += s.Length;
        }
        Console.WriteLine(count);
        Console.Write("Press Enter when done:");
        Console.ReadLine();
    }
    private void Ticktock(object s)
    {
        Console.WriteLine("Ticktock");
    }
    private void CreateTimer()
    {
        System.Threading.Timer t = new Timer(Ticktock, null, 1000, 1000);
    }
