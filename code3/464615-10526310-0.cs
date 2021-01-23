    var asms = Assembly.GetExecutingAssembly().GetReferencedAssemblies();
    foreach (var referencedAssembly in Assembly.GetExecutingAssembly().GetReferencedAssemblies())
    {
        Console.WriteLine(referencedAssembly.Name);
    }
