    public bool IsPropertyACollection(this Type type)
    {
        return (!typeof(String).Equals(type) && 
            typeof(IEnumerable).IsAssignableFrom(type));
    }
