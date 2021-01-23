    string foo = "default";
    try
    {
        foo = "test"; 
    }
    catch (Exception) 
    {
        foo = null;
    }
    finally
    {
        Console.WriteLine(foo); 
    }
