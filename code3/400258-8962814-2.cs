    var assembly = Mono.Cecil.AssemblyDefinition.ReadAssembly("protobuf-net.dll");
    foreach(var attribute in assembly.CustomAttributes)
    {
        Console.WriteLine(attribute.AttributeType.FullName);
    }
