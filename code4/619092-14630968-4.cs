    try
    {
        await FooAsync();
        await BarAsync();
        await FubarAsync();
        Console.WriteLine("All done");
    }
    catch(Exception e) // For illustration purposes only. Catch specific exceptions!
    {
        Console.WriteLine(e);
    }
