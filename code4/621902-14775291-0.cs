    var assembly = AppDomain.CurrentDomain.DefineDynamicAssembly(
        new AssemblyName("test"), AssemblyBuilderAccess.RunAndSave);
    var module = assembly.DefineDynamicModule("test.dll");
    var foo = module.DefineType("Foo");
    foo.DefineGenericParameters("T");
    var bar = module.DefineType("Bar");
    bar.DefineGenericParameters("T");
    bar.SetParent(foo);
    foo.CreateType();
    bar.CreateType();
