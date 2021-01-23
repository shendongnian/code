    public static bool operator ==(int key1, LocationKey key2)
    {
        return key1 == key2.Value;
    }
    
    public static bool operator !=(int key1, LocationKey key2)
    {
        return key1 != key2.Value;
    }
    
    public static bool operator ==(LocationKey key1, int key2)
    {
        return key1.Value == key2;
    }
    
    public static bool operator !=(LocationKey key1, int key2)
    {
        return key1.Value != key2;
    }
