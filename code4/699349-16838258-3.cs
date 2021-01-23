    public static void Main()
    {
            // Create an anonymous type with two fields
        Type myAnonymousType = CreateNewType<String, Int32>();
        dynamic myAnon = Activator.CreateInstance(myAnonymousType);
        myAnon.FieldA = "A String";
        myAnon.FieldB = 1234;
        Console.WriteLine(myAnon.FieldA); // Output : "AString"
        Console.WriteLine(myAnon.FieldB); // Output : 1234
        Console.ReadLine();
    }
    public static Type CreateNewType<TFieldTypeA, TFieldTypeB>()
    {
        // Let's start by creating a new assembly
        AssemblyName dynamicAssemblyName = new AssemblyName("MyAsm");
        AssemblyBuilder dynamicAssembly = AssemblyBuilder.DefineDynamicAssembly(dynamicAssemblyName, AssemblyBuilderAccess.Run);
        ModuleBuilder dynamicModule = dynamicAssembly.DefineDynamicModule("MyAsm");
        // Now let's build a new type
        TypeBuilder dynamicAnonymousType = dynamicModule.DefineType("MyAnon", TypeAttributes.Public);
        // Let's add some fields to the type.
        FieldInfo dynamicFieldA = dynamicAnonymousType.DefineField("FieldA", typeof(TFieldTypeA), FieldAttributes.Public);
        FieldInfo dynamicFieldB = dynamicAnonymousType.DefineField("FieldB", typeof(TFieldTypeB), FieldAttributes.Public);
        // Return the type to the caller
        return dynamicAnonymousType.CreateType();
    }
