    private int Length { get; set; }
    private int _length;
    void Run()
    {
        Length = int.MaxValue;
        _length = int.MaxValue;
        var watch = new Stopwatch();
        watch.Start();
        for (int i = 0; i < Length; i++)
        {
        }
        watch.Stop();
        Console.WriteLine("Elapsed: {0}ms", watch.ElapsedMilliseconds);
        watch.Restart();
        for (int i = 0; i < _length; i++)
        {
        }
        watch.Stop();
        Console.WriteLine("Elapsed: {0}ms", watch.ElapsedMilliseconds);
    }
