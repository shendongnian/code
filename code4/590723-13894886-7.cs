    ...
    } else {
        // We have a list or array of a complex type
        List<object> subKeys = new List<object>();
        var classDescr = new Class { Name = genericArgType.Name, Structure = subKeys };
        if (i == 0)
            keys.Add(classDescr);
        List<object> subValues = new List<object>();
        itemValues.Add(subValues);
        SplitKeyValues(
            (IList)prop.GetValue(item, null), subKeys, subValues);
    }
    ...
