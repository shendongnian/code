    int n = 10;
    for (int i = 0; i < n; ++i)
    {
        for (int j = 0; j <= i; ++j)
            Console.Write("*");
        for (int j = 0; j < n-i-1; ++j)
            Console.Write(" ");
        for (int j = 0; j < n-i; ++j)
            Console.Write("*");
        for (int j = 0; j < 2*i; ++j)
            Console.Write(" ");
        for (int j = 0; j < n-i; ++j)
            Console.Write("*");
        for (int j = 0; j < n-i-1; ++j)
            Console.Write(" ");
        for (int j = 0; j <= i; ++j)
            Console.Write("*");
        Console.WriteLine();
    }
