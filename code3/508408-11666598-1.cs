    var nameCount = new Dictionary<string, int>();
    foreach (String s in File.ReadAllLines("filename"))
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
