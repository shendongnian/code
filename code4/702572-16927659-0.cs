    try
    {
        try
        {
            throw new Exception("This is an exception.");
        }
        catch(Exception foo)
        {
            System.Console.WriteLine(foo.Message);
            throw; // rethrows foo for the next handler.
        }
    }
    catch(Exception bar)
    {
        System.Console.WriteLine("And again: " + bar.Message);
    }
