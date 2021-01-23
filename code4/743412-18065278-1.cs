    List<string> wordstoKeep = new List<string>() { "ASCB", "Arinc" };
    foreach (string str in listB)
    {
        int index = listA.FindIndex(x => x.Equals(str, StringComparison.OrdinalIgnoreCase));
        if (index >= 0)
        {
           if (!wordstoKeep.Any(x => x.Equals(str, StringComparison.OrdinalIgnoreCase)))
               listA.RemoveAt(index);
        }
        else
           listA.Add(str);
    }
 
