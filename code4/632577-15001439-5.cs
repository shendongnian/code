    public void Function(string assemblyName, string namespace)
    {
        var type1Name = namespace + ".Type1, " + assemblyName;
        var type2Name = namespace + ".Type2, " + assemblyName;
        dynamic type1 = Activator.CreateInstance(Type.GetType(type1Name));
        dynamic type2 = Activator.CreateInstance(Type.GetType(type1Name));
        type1.InnerType = type2;
        type1.PerformMethod1();
    }
