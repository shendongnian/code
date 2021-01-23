    var parameters = CompilerParameters
    {
        GenerateExecutable = true,
        OutputAssembly = Output,
        ReferencedAssemblies = {
            "System.dll",
            "System.Core.dll",
            // etc
        }
    };
