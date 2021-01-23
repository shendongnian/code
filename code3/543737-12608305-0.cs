    string assemblyFile = @"D:\My Documents\Visual Studio 2008\Projects\ClassLibrary1\bin\x64\Debug\AssemblyB.dll";
    byte[] assemblyBytes = File.ReadAllBytes(assemblyFile);
    
    var assembly = Assembly.Load(assemblyBytes); // Get assembly B 
    var description = assembly.GetCustomAttributes(false).OfType<AssemblyDescriptionAttribute>().SingleOrDefault(); 
    var category = assembly.GetCustomAttributes(false).OfType<AssemblyCategoryAttribute>().SingleOrDefault();
