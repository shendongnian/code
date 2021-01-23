    var assemblies = new List<AssemblyName>(Assembly.GetEntryAssembly().GetReferencedAssemblies());
    assemblies.Add(Assembly.GetEntryAssembly().GetName());
    var nss = assemblies.Select(name => Assembly.Load(name))
                .SelectMany(asm => asm.GetTypes())
                .Where(type=>type.Namespace!=null)
                .Where(type=>type.Namespace.StartsWith("System.Collections"))
                .Select(type=>type.Namespace)
                .Distinct()
                .ToList();
               
