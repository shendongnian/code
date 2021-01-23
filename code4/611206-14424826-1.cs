    // Get current assembly
    var thisAssembly = this.GetType().Assembly;
    // Get title attribute (if any)
    var titleAttribute = thisAssembly
            .GetCustomAttributes(typeof(AssemblyTitleAttribute), false)
            .Cast<AssemblyTitleAttribute>()
            .FirstOrDefault();
    if (titleAttribute != null)
    {
        Console.WriteLine(titleAttribute.Title);
    }
