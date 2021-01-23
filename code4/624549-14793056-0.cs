    var initialName = AssemblyName.GetAssemblyName("Foo.dll");
    Console.WriteLine(initialName);
    Console.WriteLine(initialName.Version);
    // replaced the dll manually
    
    initialName = AssemblyName.GetAssemblyName("Foo.dll");
    Console.WriteLine(initialName);
    Console.WriteLine(initialName.Version);
