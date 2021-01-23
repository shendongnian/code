    public static object GetProcessor(string name)
    {
        Type type = Type.GetType(name + "Processor");
        return Activator.CreateInstance(type);
    }
