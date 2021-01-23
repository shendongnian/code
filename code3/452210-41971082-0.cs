    public static string GetAssemblyDescription(this Assembly assembly)
    {
        return assembly.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false)
            .OfType<AssemblyDescriptionAttribute>().SingleOrDefault()?.Description;
    }
