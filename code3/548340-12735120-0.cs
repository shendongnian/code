    Assembly
        .GetExecutingAssembly()
        .GetReferencedAssemblies()
        .Select(a => Assembly.Load(a.FullName))
        .Where(a => a.
                .GetCustomAttributes(false)
                .OfType<AssemblyCategoryAttribute>()
                .Any())
        .ToList();
