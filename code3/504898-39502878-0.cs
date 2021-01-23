    public IDictionary<T, V> toDictionary<T, V>(Object objAttached)
    {
        var dicCurrent = new Dictionary<T, V>();
        foreach (DictionaryEntry dicData in (objAttached as IDictionary))
        {
            dicCurrent.Add((T)dicData.Key, (V)dicData.Value);
        }
        return dicCurrent;
    }
