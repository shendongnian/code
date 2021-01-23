    var queue = new BlockingCollection<ConsoleKeyInfo>();
    new Thread(() =>
    {
        while (true) queue.Add(Console.ReadKey(true));
    })
    { IsBackground = true }.Start();
    Console.Write("Welcome! Please press a key: ");
    ConsoleKeyInfo cki;
    if (queue.TryTake(out cki, TimeSpan.FromSeconds(10))) //wait for up to 10 seconds
    {
        Console.WriteLine();
        Console.WriteLine("You pressed '{0}'", cki.Key);
    }
    else
    {
        Console.WriteLine();
        Console.WriteLine("You did not press a key");
    }
