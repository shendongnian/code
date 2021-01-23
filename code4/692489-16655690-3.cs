    Test test1 = new Test { Value = 1, Name = "1" };
    Test test2 = new Test { Value = 1, Name = "2" };
    if (test1 == test2)
        Console.WriteLine("test1 == test2"); // This gets printed.
    else
        Console.WriteLine("test1 != test2");
    if (test1.Equals(test2))
        Console.WriteLine("test1.Equals(test2)");
    else
        Console.WriteLine("NOT test1.Equals(test2)"); // This gets printed!
