    int[] gapCounts = new int[21];
    int gap = 0;
    // simulate a few gaps using your algo
    var random = new Random();
    for (int x = 0; x < 100000; x++)
    {
        if (random.Next(11) == 1)
        { // count that gap
            gapCounts[gap]++;
            gap = 0;
        }
        else
        {
            gap++;
            if(gap >= gapCounts.Length)
            { // just skip anything too large, sorry
                gap = 0;
            }
        }
    }
    decimal total = gapCounts.Sum();
    for(int i = 0 ; i < gapCounts.Length ; i++)
    {
        Console.WriteLine("{0:00}: {1:00.0%}", i, gapCounts[i] / total);
    }
