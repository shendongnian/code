    DateTime start = DateTime.Now;
    for (int i = 1; i < 100000; i++)
    {
        if ((DateTime.Now - start).TotalSeconds >= 15)
            break;
        Console.WriteLine("This is test no. "+ i+ "\n");
    }
