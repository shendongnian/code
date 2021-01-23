    var assembly = Assembly.GetExecutingAssembly();
    var resourceName = "AssemblyName.MyFile.txt";
    using (Stream stream = assembly.GetManifestResourceStream(resourceName))
    {
        using (StreamReader reader = new StreamReader(stream))
        {
            string result = reader.ReadToEnd();
        }
    }
