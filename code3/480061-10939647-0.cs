    private HashTable CustomProperties { get; set; }
    //Note: all three of these functions are unecessary if you make the hashtable public, but they do look good as far as an interface goes.
    public void AddCustomProperty (String key, Object value)
    {
        CustomProperties.Add(key, value);
    }
    public void RemoveCustomProperty (String key)
    {
        CustomProperties.Remove(key);
    }
    public object GetCustomProperty (String key)
    {
        return CustomProperties[key];
    }
