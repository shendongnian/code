    var changed = new Dictionary<Object, Object>();
    foreach (DictionaryEntry entry in e.NewValues)
    {
        if (e.OldValues[entry.Key] != entry.Value)
        {
            changed.Add(entry.Key, entry.Value);
        }
    }
 
      
