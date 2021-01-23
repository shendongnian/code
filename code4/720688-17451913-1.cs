    copyTo.Start();
    for (int i = 0; i < 1000; ++i)
    {
        string[] copyToAnimals = new string[animals.Length];
        animals.CopyTo(copyToAnimals, 0);
    }
    copyTo.Stop();
    Console.WriteLine("Copy to: " + copyTo.Elapsed);
