    var originalConsoleOut = Console.Out; // preserve the original stream
    using(var writer = new StringWriter())
    {
        Console.SetOut(writer);
        Console.WriteLine("some stuff"); // or make your DLL calls :)
        writer.Flush(); // when you're done, make sure everything is written out
        var myString = writer.GetStringBuilder().ToString();
    }
    Console.SetOut(originalConsoleOut); // restore Console.Out
