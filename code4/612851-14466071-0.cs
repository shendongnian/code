    const int ILITERATIONS = 10000000;
    const long testValue = 8616519696198198198;
    byte[] testBytes = BitConverter.GetBytes(testValue);
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();
    for (int i = 0; i < ILITERATIONS; i++)
    {
        ByteArrayToStructure1<long>(testBytes);
    }
    stopwatch.Stop();
    Console.WriteLine("1: "+stopwatch.ElapsedMilliseconds);
    stopwatch.Reset();
    stopwatch.Start();
    for (int i = 0; i < ILITERATIONS; i++)
    {
        ByteArrayToStructure1<long>(testBytes);
    }
    stopwatch.Stop();
    Console.WriteLine("2: " + stopwatch.ElapsedMilliseconds);
    stopwatch.Reset();
    stopwatch.Start();
    for (int i = 0; i < ILITERATIONS; i++)
    {
        BitConverter.ToInt64(testBytes, 0);
    }
    stopwatch.Stop();
    Console.WriteLine("3: " + stopwatch.ElapsedMilliseconds);
    Console.ReadLine();
