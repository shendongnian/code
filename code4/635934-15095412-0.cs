    if (!dictionary.ContainsKey(name))
    {
        lock (lockdictionary)
        {
            if (!dictionary.ContainsKey(name))
            {
                value = new foo();
                dictionary[name] = value;
            }
            value = dictionary[name];
        }
    }
