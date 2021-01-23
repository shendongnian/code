    int[] x = new int[10];
    Random r = new Random();
    while (x.Any(item => item == 1) == false)
    {
        for (int i = 0; i < x.Length; i++)
        {
             x[i] = r.Next(0, 2);
        }
    }
    for (int i = 0; i < x.Length; i++)
    {
       Console.WriteLine(x[i]);
    }
