    int[,] foo2 = new int[2, 3];
    foreach (var type in foo2.GetType().GetInterfaces())
    {
        Console.WriteLine("{0}", type.ToString());
    }
