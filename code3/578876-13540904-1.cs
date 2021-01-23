    var resolver = new MyDefaultAssemblyResolver();
    resolver.AddSearchDirectory("FolderOfMyAssembly");
    var parameters = new ReaderParameters
    {
        AssemblyResolver = resolver,
    };
    AssemblyDefinition assembly = AssemblyDefinition.ReadAssembly("PathToMyAssembly", parameters);
