    var names = str.Split();
    for (int i = 0; i < names.Length; i++)
    {
        Console.Write(names[i] + '\t');
        if ((i + 1) % 4 == 0)
            Console.WriteLine();
    }
