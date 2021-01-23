    loadedIntegrations.Clear();
    if (!Directory.Exists(path))
        return;
    DirectoryInfo di = new DirectoryInfo(path);
    FileInfo[] files = di.GetFiles("*.dll");
    foreach (var file in files)
    {
        Assembly newAssembly = Assembly.LoadFile(file.FullName);
        Type[] types = newAssembly.GetExportedTypes();
        foreach (var type in types)
        {
            //If Type is a class and implements the IntegrationInterface interface
            if (type.IsClass && (type.GetInterface(typeof(IntegrationInterface).FullName) != null))
                loadedIntegrations.Add(type);
        }
    }
