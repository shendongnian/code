    public int countElements(Type type)
    {
        if (!type.IsEnum)
            throw new InvalidOperationException();
        return Enum.GetNames(type).Length;
    }
    
    public void foo()
    {
        int num = countElements(typeof(ELEMENT));
    }
