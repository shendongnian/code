    var oldIn = Console.In;
    try
    {
        Console.SetIn(new StringReader("some input"));
        
        using (App app = new App())
        {
            // input = Console.In.ReadToEnd(); happens here
            result = app.Run(args);
        }
        
        if (result != 0)
        {
            Assert.Fail("Failed");
        }
    }
    finally
    {
        Console.SetIn(oldIn);
    }
