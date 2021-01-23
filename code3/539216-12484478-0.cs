    Dictionary<string, int> dict = new Dictionary<string, int>
    {
        { "Hello World", 1 },
        { "HelloWorld", 1 },
        { "Hello  World", 1 },
    };
    
    foreach (var item in dict) // var is of type KeyValuePair<string, int>
        Console.WriteLine(item.Key + ", " + item.Value);
