    public bool TryGetValue(TKey key, out TValue value)
    {
        int index = this.FindEntry(key);
        if (index >= 0)
        {
            value = this.entries[index].value;
            return true;
        }
        value = default(TValue);
        return false;
    }
    public bool ContainsKey(TKey key)
    {
        return (this.FindEntry(key) >= 0);
    }
