    foreach (DictionaryEntry de in GetTheDictionary())
    {
        Console.WriteLine("Key type" + de.Key.GetType());
        Console.WriteLine("Value type" + de.Value.GetType());
    }
