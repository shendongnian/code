    AssemblyFileVersionAttribute attr = typeof(MyController).Assembly.GetCustomAttributes(typeof(AssemblyFileVersionAttribute), true).OfType<AssemblyFileVersionAttribute>().FirstOrDefault();
    
    if (attr != null)
    {
        return attr.Version;
    }
