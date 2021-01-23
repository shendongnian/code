    SortedList _dims = GetList("mysortedlist");
    foreach (DictionaryEntry kvp in _dims)
    {
        Console.WriteLine(kvp.Key.ToString());
        Console.WriteLine(kvp.Value.ToString()); 
    }
