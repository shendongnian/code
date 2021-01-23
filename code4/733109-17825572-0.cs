    var folder = Package.Current.InstalledLocation;
    foreach (var file in await folder.GetFilesAsync())
    {
        if (file.FileType == ".dll")
        {
            var assemblyName = new AssemblyName(file.DisplayName);
            var assembly = Assembly.Load(assemblyName);
            foreach (var type in assembly.ExportedTypes)
            {
                // check type and do something with it
            }
        }
    }
