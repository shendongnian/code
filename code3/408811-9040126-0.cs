    int[] n = { 4, 7, 29, 3, 87 };
    int max = 0;
    int min = int.MaxValue;
    double avg = 0;
    foreach (int i in n)
    {
        if (i > max)
            max = i;
        if (i < min)
           min = i;
       avg += i;
    }
    avg = avg / n.Count - 2;
