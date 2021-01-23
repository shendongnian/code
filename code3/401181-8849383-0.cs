    public static IEnumerable<string> GetDependentAssembly(string assemblyFilePath)
    {
       //On my box, once I'd installed Mono, Mono.Cecil could be found at: 
       //C:\Program Files (x86)\Mono-2.10.8\lib\mono\gac\Mono.Cecil\0.9.4.0__0738eb9f132ed756\Mono.Cecil.dll
       var assembly = AssemblyDefinition.ReadAssembly(assemblyFilePath, new ReaderParameters(ReadingMode.Deferred));
       return assembly.MainModule.AssemblyReferences.Select(reference => reference.FullName);
    }
