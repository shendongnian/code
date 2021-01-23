    bool TryGetNestedValue (this IDictionary dict, out object value, 
        params object[] keys)
    {
        for(int i = 0; i < keys.Length; i++)
        {
            var key = keys[i];
            if (!dict.Contains(key))
            {
                value = null;
                return false;
            }
            if (i == keys.Length - 1)
            {
                value = dict[key];
                return true;
            }
            dict = dict[key];
        }
        throw new ArgumentException("keys");
    }
