    public void AddItem(int key, int value)
    {
        List<int> values;
        if (_dictionary.TryGetValue(key, out values))
        {
            values = new List<int>();
            _dictionary.Add(key, values);
        }
    
        values.Add(value);
    }
