    public bool IsPropertyACollection(this PropertyInfo property)
    {
        return (!typeof(String).Equals(property.PropertyType) && 
            typeof(IEnumerable).IsAssignableFrom(property.PropertyType));
    }
