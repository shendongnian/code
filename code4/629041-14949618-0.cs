    /// <summary>
    /// Writes an assembly, containing the given method, to the working directory.
    /// The assembly, type, and method are named based on the given hash name.
    /// </summary>
    public static void WriteMethodToAssembly<T>(Expression<T> method, string hashName) {
        var assemblyName = new AssemblyName(hashName);
        var assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.RunAndSave);
        var moduleBuilder = assemblyBuilder.DefineDynamicModule(assemblyName.Name, assemblyName.Name + ".dll");
        var typeBuilder = moduleBuilder.DefineType(hashName, TypeAttributes.Public);
        var methodBuilder = typeBuilder.DefineMethod("Run" + hashName, MethodAttributes.Public | MethodAttributes.Static);
        method.CompileToMethod(methodBuilder);
        typeBuilder.CreateType();
        assemblyBuilder.Save(hashName + ".dll");
    }
