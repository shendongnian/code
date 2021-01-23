    public void WriteAssemblyLocations()
    {
        Assembly[] assList = AppDomain.CurrentDomain.GetAssemblies();
        foreach (Assembly assembly in assList)
        {
            Console.WriteLine(assembly.Location);
        }
    }
