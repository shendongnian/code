    var inputString = File.ReadAllText("filename");
    var nameCount = new Dictionary<string, int>();
    foreach (String s in inputString.Split(new[]{' '}))
    {
        if (nameCount.ContainsKey(s))
        {
            nameCount[s] = nameCount[s] + 1;
        }
        else
        {
            nameCount.Add(s, 1);
        }
    }
    // and printing
    foreach (var pair in nameCount)
    {
        Console.WriteLine("{0} count:{1}", pair.Key, pair.Value);
    }
