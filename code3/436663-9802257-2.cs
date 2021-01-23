    const int size = 3000000;
    const int subSize = 100;
    var stringBuilder = new StringBuilder(size);
    var random = new Random();
    for (var i = 0; i < size; i++)
    {
        stringBuilder.Append((char)random.Next(30, 80));
    }
    var hugeString = stringBuilder.ToString();
    var stopwatch = Stopwatch.StartNew();
    for (int i = 0; i < 1000; i++)
    {
        var strings = Scan(hugeString, subSize);
    }
    stopwatch.Stop();
    Console.WriteLine(stopwatch.ElapsedMilliseconds / 1000); // 43
