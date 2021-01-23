    IEnumerable<DictionaryEntry> EnumerateEntries(IDictionary d)
    {
        foreach (DictionaryEntry de in d) 
        {
            yield return de;
        }
    }
    // ...
    genericDictionary = EnumerateEntries(genericDictionary).OrderBy(…).ToDictionary(…);
