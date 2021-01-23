    foreach (var entry in results)
    {
        Console.WriteLine(entry.Key + ": ");
        foreach (string word in entry.Value)
        {
            Console.WriteLine(word);
        }
    }
