    Dictionary<string, Dictionary<string, string>> dict = new Dictionary<string,Dictionary<string,string>>();
    foreach (var kvp in dict)
    {
        var innerDict = kvp.Value;
        foreach (var innerKvp in innerDict)
        {
            Console.WriteLine(kvp.Key + " " + innerKvp.Key + " " + innerKvp.Value);
        }
    }
