    int exceptions = 0;
    int noExceptions = 0;
    for (int x = 0; x < 100; ++x)
    {
        Queue<int> q = new Queue<int>();
        try
        {
            Parallel.For(1,1000001,(i) => q.Enqueue(i)); 
            ++noExceptions;
        }
        catch
        {
            ++exceptions;
        }
    }
    
    Console.WriteLine("Runs with exception: {0}. Runs without: {1}", exceptions, noExceptions);
