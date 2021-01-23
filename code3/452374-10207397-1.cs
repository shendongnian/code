    IDictionary dictionary = (IDictionary)field.GetValue(this);
    Dictionary<string, object> newDictionary = CastDict(dictionary)
                                               .ToDictionary(entry => (string)entry.Key,
                                                             entry => entry.Value);
    private IEnumerable<DictionaryEntry> CastDict(IDictionary dictionary)
    {
        foreach (DictionaryEntry entry in dictionary)
        {
            yield return entry;
        }
    }
