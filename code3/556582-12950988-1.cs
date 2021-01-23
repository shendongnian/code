    static object Evil()
    {
        var ab = AppDomain.CurrentDomain.DefineDynamicAssembly(
            new AssemblyName("foo"), AssemblyBuilderAccess.Run);
        var mb = ab.DefineDynamicModule("foo");
        var eb = mb.DefineEnum("bar", TypeAttributes.Public, typeof(int));
        eb.DefineLiteral("42", 0);
        Type t = eb.CreateType();
        return Enum.ToObject(t, 0);
    }
