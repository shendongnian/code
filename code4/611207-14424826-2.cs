    // Get current assembly
    var thisAssembly = this.GetType().Assembly;
    // Get title attribute (on .NET 4)
    var titleAttribute = thisAssembly
            .GetCustomAttributes(typeof(AssemblyTitleAttribute), false)
            .Cast<AssemblyTitleAttribute>()
            .FirstOrDefault();
    // Get title attribute (on .NET 4.5)
    var titleAttribute = thisAssembly.GetCustomAttribute<AssemblyTitleAttribute>();
    if (titleAttribute != null)
    {
        var title = titleAttribute.Title;
        // Do something with title...
    }
