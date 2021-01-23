    const int size = 10000000;
    object[] array1 = new object[size];
    object[] array2 = new object[size];
    Random random;
    random = new Random(0);
    for (int i = 0; i < size; i++)
    {
        array1[i] = random.Next();
        array2[i] = random.Next();
    }
    Stopwatch stopwatch = new Stopwatch();
    Console.ReadKey();
    stopwatch.Restart();
    for (int i = 0; i < size; i++)
        array1[i] = array2[i];
    stopwatch.Stop();
    Console.WriteLine("Indexer method: {0}", stopwatch.Elapsed);
    random = new Random(0);
    for (int i = 0; i < size; i++)
    {
        array1[i] = random.Next();
        array2[i] = random.Next();
    }
    Console.ReadKey();
    stopwatch.Restart();
    for (int i = 0; i < size; i++)
        array1.SetValue(array2.GetValue(i), i);
    stopwatch.Stop();
    Console.WriteLine("Get/SetValue method: {0}", stopwatch.Elapsed);
