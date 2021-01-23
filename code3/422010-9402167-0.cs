    System.Int32 x, y;
    System.Int64 z;
    System.Random rand = new System.Random(DateTime.Now.Millisecond);
    for (int i = 0; i < 6; i++)
    {
        x = rand.Next(int.MinValue, int.MaxValue);
        y = rand.Next(int.MinValue, int.MaxValue);
        z = ((Int64)x * y); //by casting x, we "promote" the entire expression to 64-bit.
        Console.WriteLine("{0} * {1} = {2}", x, y, z);
    }
