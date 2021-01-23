    // Helper method to avoid having to create an array implicitly
    public static List<T> CreateList<T>(T value)
    {
        return new List<T> { value };
    }
    // Add more overloads for a few parameters, e.g. (T value1, T value2)
    
    // More general version
    public static List<T> CreateList<T>(params T[] values)
    {
        return values.ToList();
    }
