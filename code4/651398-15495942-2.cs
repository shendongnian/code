        int total = 0;
        while (true)
        {
            int initial = Thread.VolatileRead(ref _counter);
            if (initial >= _max)
            {
                break;
            }
            int computed = initial + 1;
            Interlocked.CompareExchange(ref _counter, computed, initial);
            total++;
        }
        Console.WriteLine(total);
