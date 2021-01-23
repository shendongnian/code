    Dictionary<ClassEnum, Type> TypeDictionary = new Dictionary<ClassEnum, Type>();
    
    public void InitDictionary()
    {
        TypeDictionary.Add(ClassEnum.FirstClass, typeof(FirstClass));
        //etc...
    }
    
    public object Factory(ClassEnum class)
    {
        if (!TypeDictionary.ContainsKey(class))
            return null;
    
        var constructor = TypeDictionary[class].GetConstructor(....);
        return constructor.Invoke(....);
    }
