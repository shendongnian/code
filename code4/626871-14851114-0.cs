    for (int y = 1; y < width * 2; y++)
    {
        int numOs = width - Math.Abs(width - y);
        for (int x = 0; x < numOs; x++)
        {
            Console.Write("O");
        }
        Console.WriteLine();
    }
