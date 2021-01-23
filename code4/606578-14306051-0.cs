    List<String> input = new List<String> { "1", "2", "three", "4", "-2" };
    
    List<UInt32?> converted = input.ConvertAll(s =>
    {
        UInt32? result;
    
        try
        {
            result = UInt32.Parse(s);
        }
        catch
        {
            result = null;
            Console.WriteLine("Attempted conversion of '{0}' failed.", s);
        }
    
        return result;
    });
