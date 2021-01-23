    var oldIn = Console.In;
    try
    {
        Console.SetIn(new StringReader("some input"));
        
        // Read the input here
        string input = Console.In.ReadToEnd();
        // or call app.Run is the reading happens inside
        
        // Now run the test using the input
    }
    finally
    {
        Console.SetIn(oldIn);
    }
