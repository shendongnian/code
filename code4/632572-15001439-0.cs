    public void Function(string namespace)
    {
        dynamic type1 = Activator.CreateInstance(namespace + ".Type1");
        dynamic type2 = Activator.CreateInstance(namespace + ".Type2");
        type1.InnerType = type2;
        type1.PerformMethod1();
    }
