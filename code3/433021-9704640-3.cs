    public PropertyInfo[] SortedList()
    {
        PropertyInfo[] properties = typeof(Foo).GetProperties();
        Array.Sort(properties, new PropertyInfoComparer());
        return properties;
    }
