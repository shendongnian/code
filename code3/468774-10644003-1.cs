    if (p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(System.Collections.Generic.List<>))
    {
        object val1 = p.GetValue(Original, null);
        object val2 = p.GetValue(Modified, null);
        // First check count...
        PropertyInfo countProperty = p.PropertyType.GetProperty("Count");
        int count1 = countProperty.GetValue(val1, null);
        int count2 = countProperty.GetValue(val2, null);
        if (count1 != count2) return true;
        // Now iterate:
        var enumerator1 = (val1 as System.Collections.IEnumerable).GetEnumerator();
        var enumerator2 = (val2 as System.Collections.IEnumerable).GetEnumerator();
        while (enumerator1.MoveNext())
        {
            enumerator2.MoveNext();
            // check for null, skipping here...
            object elem1 = enumerator1.Current;
            object elem2 = enumerator2.Current;
            if (HasPropertyChanged(elem1.GetType(), elem1, elem2, IgnoreProperties)) return true;
        }
    }
    // ...
