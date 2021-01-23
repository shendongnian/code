    // Store each of your searchable lists here
    Dictionary<string, IEnumerable<MyType>> DictionaryOfSelectedValues = ...;
    
    Type t = MyType.GetType();
    // For each list of searchable values
    foreach(var selectedValues in DictionaryOfSelectedValues) // Returns KeyValuePair<TKey, TValue>
    {
        var localSelected = selectedValues;
        // Try to get a property for this key
        PropertyInfo prop = t.GetProperty(selectedValues.Key);
        if( prop != null )
        {
            Results = Results.Union(Potential.Where(x =>
                    localSelected.Contains(prop.GetValue(x, null))));
        }
        else // If it's not a property, check if the entry is for a field
        {
            FieldInfo field = t.GetField(selectedValues.Key);
            if( field != null )
            {
                Results = Results.Union(Potential.Where(x =>
                        localSelected.Contains(field.GetValue(x, null))));
            }
        }
    }
