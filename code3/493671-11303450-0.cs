    for (int i = 0; i <= 3; i++)
    {
        Console.Write(i + "\t");
        for (int j = 1; j <= 3; j++)
        {
            if (i>0) Console.Write(i * j + "\t");
            else Console.Write(j + "\t");
        }
        Console.Write("\n");
    }
