    using System.Reflection;
    using System.IO;
    
    ...
    
    // Get assembly 
    AssemblyName currentAssembly = AssemblyName.GetAssemblyName(path);
    Version assemblyVersion = currentAssembly.Version;
