    var randomNumberGenerator = new Random();
    for (int x = 0; x < 10000; ++x)
    {
        for (int i = 0; i < 2000; ++i)
            for (int j = 0; j < 2000; ++j)
                li[x].SetPixel(i, j, System.Drawing.Color.FromArgb(randomNumberGenerator.Next()));
        Console.WriteLine(x);
    }
