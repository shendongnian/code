    using Mono.Cecil;
    using Mono.Cecil.Cil;
    
    var assembly = AssemblyDefinition.ReadAssembly("ClassLibrary.dll");
    // skip the first type '<Module>' whatever that is.
    var types = assembly.MainModule.Types.Skip(1);
    foreach (var type in types)
    {
        var interfaces = type.Interfaces.Select(i => i.FullName);
        if (interfaces.Any())
        {
             Console.WriteLine("{0} : {1}, {2}", type.FullName, type.BaseType.FullName, string.Join(", ", interfaces));
        }
        else
        {
             Console.WriteLine("{0} : {1}", type.FullName, type.BaseType.FullName);
        }
    }
