    static void Main()
    {
        var test = new TestStruct
        {
            A = 1,
            B = 3
        };
        var bytes = GetBytes(test);
        var duplicate = Reconstitute(bytes);
        Console.WriteLine("Original");
        PrintObject(test, 1);
            
        Console.WriteLine();
        Console.WriteLine("Reconstituted");
        PrintObject(duplicate, 1);
        Console.ReadLine();
    }
