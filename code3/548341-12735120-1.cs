    Assembly
        .GetExecutingAssembly()
        .GetReferencedAssemblies()
        .Select(Assembly.Load)
        .Where(a => a.IsDefined(typeof(AssemblyCategoryAttribute), false))
        .ToList();
