    static void UpdateVersionInfo(Assembly assembly)
    {
        foreach (Type type in assembly.GetTypes())
        {
            var attribute = 
                type.GetCustomAttributes(typeof (UtilVersionAttribute), true)
                    .FirstOrDefault();
            if(attribute != null)
                GlobalConstants.Lst.Add((attribute as UtilVersionAttribute).VersionInfo);
        }
    }
    static void Main(string[] args)
    {
        var assembly = Assembly.GetExecutingAssembly();
        UpdateVersionInfo(assembly);
        GlobalConstants.Lst.ForEach(Console.WriteLine);
    }
