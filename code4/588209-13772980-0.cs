    Dictionary<string, int> dict = new Dictionary<string, int>();
    string keyToRemove = null;
    foreach (var kvp in dict)
    {
        if (kvp.Value == 0)
        {
            keyToRemove = kvp.Key;
            break;
        }
    }
    if (keyToRemove != null)
    {
        dict.Remove(keyToRemove);
    }
