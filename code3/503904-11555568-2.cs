    public override bool Equals(object obj)
    {
        CustomDictionary other = obj as CustomDictionary;
        if (other == null)
            return false;
    
        if (Count != other.Count)
            return false;
    
        foreach (string key in Keys)
        {
            if (!other.ContainsKey(key))
                return false;
    
            if (this[key] != other[key])
                return false;
        }
    
        foreach (string key in other.Keys)
        {
            if (!ContainsKey(key))
                return false;
        }
    
        return true;
    }
