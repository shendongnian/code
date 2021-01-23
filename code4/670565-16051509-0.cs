    using Mono.Cecil;
    using Mono.Cecil.Cil;
    
    var assembly = AssemblyDefinition.ReadAssembly("ClassLibrary.dll");
    // skip the first type '<Module>' whatever that is.
    var types = assembly.MainModule.Types.Skip(1);
    
    foreach (var type in types)
    {
       Console.WriteLine("{0} : {1}", type.FullName, type.BaseType.FullName);
    }
