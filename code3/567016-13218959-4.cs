    Stopwatch watch = new Stopwatch();
    watch.Start();
    for (int i = 1; i < 100000; i++)
    {
        if (watch.Elapsed.TotalMilliseconds >= 500)
            break;
        Console.WriteLine("This is test no. " + i + "\n");
    }
    watch.Stop();
