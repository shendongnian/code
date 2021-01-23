    Dictionary<string, int> dictFilesNotThereCopy = new Dictionary<string, int>();
    int counter = 0;
    foreach (KeyValuePair<string,int> item in dictFilesNotThere)
    {
        if (dictFilesNotThereCopy.ContainsKey(item.Key.Remove(8, 3)))
            dictFilesNotThereCopy.Add((item.Key.Remove(8, 3) + (counter++)).ToString(), item.Value);
        else
            dictFilesNotThereCopy.Add(item.Key.Remove(8, 3), item.Value);
    }
