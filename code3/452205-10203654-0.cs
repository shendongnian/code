    AssemblyDescriptionAttribute attribute = assembly
        .GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false)
        .OfType<AssemblyDescriptionAttribute>()
        .SingleOrDefault();
    
    if(attribute != null)
    {
        Console.WriteLine(attribute.Description);
    }
