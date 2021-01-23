    var counts = new Dictionary<string, int>();
    foreach(string item in array1)
    {
        if (counts.ContainsKey(item))
            counts[item]++;
        else
            counts[item] = 1;
    }
    foreach(string item in array2)
    {
        if (counts.ContainsKey(item))
            counts[item]++;
        else
            counts[item] = 1;
    }
    // Print out counts
    foreach(var kvp in counts)
        Console.WriteLine("{0} = {1}", kvp.Key, kvp.Value);
