    Dictionary<ClassEnum, Type> TypeDictionary = new Dictionary<ClassEnum, Type>();
    
    public void InitDictionary()
    {
        TypeDictionary.Add(ClassEnum.FirstClass, typeof(FirstClass));
        //etc...
    }
    
    public object Factory(ClassEnum type)
    {
        if (!TypeDictionary.ContainsKey(type))
            return null;
    
        var constructor = TypeDictionary[type].GetConstructor(....);
        return constructor.Invoke(....);
    }
