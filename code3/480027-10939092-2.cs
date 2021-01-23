    public static DataElement Create(string name)
    {
        return new DataElement(name);
    }
    public static DataElement CreateParam(string name, int defaultInt);
    {
        return new DataElement(ElementKind.IntParam, name);
        // ... use defaultInt ... 
    }
    // similar to above
    public static DataElement CreateParam(string name, double defaultDouble); 
    public static DataElement CreateLocal(string name);
