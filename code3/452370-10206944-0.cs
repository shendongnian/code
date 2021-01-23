    FieldInfo field = this.GetType().GetField(fieldName);
    IDictionary dictionary = (IDictionary)field.GetValue(this);
    Dictionary<string, object> newDictionary = 
        dictionary
        .Cast<DictionaryEntry>()
        .ToDictionary(entry => (string)entry.Key,
                      entry => entry.Value);
