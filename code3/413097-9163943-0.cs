    void Register<T>(T service) 
    { 
        var type = typeof(T); 
        if (type.IsInterface)
        {
            Register(type);
            return;
        }
        var interfaceType = ChooseTheAppropriateInterface(type);
        Register(interfaceType);
    } 
    void Register(Type typeToRegister)
    {
        //...
    }
    Type ChooseTheAppropriateInterface(Type concreteType)
    {
        var interfaces = concreteType.GetInterfaces();
        //... some logic to pick and return the interface to register
    }
