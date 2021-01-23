    public bool CompareMyTypes<T>(T type1, T type2)
        where T : ModelElement
    {
        return type1.id == type2.id; // Comparison logic here.
    }
    public bool CompareMyTypes<T1, T2>(T1 type1, T2 type2)
        where T1 : ModelElement
        where T2 : ModelElement
    {
        return type1.id == type2.id; // Comparison logic here.
    }
