    public static Array ConvertToArray(ICollection collection, Type type)
    { 
        var array = Array.CreateInstance(type, collection.Count);
    
        collection.CopyTo(array, 0);
    
        return array;
    }
