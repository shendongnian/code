    string baseAddress = "http://localhost:8080/";
    var client = new HttpClient() 
    { 
        BaseAddress = new Uri(baseAddress), 
        Timeout = TimeSpan.FromMilliseconds(1) 
    };
    try
    {
        var s = await client.GetAsync();
    }
    catch(Exception e)
    {
        Console.WriteLine(e.Message);
        Console.WriteLine(e.InnerException.Message);
    }
